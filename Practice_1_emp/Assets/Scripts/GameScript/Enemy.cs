using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpForce;
    public float agroRange;
    public int enemyhealth;

    public GameObject target;
    public GameManager gM;

    private Rigidbody2D enemyRb;

    bool shouldJump,isGameOver;

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
        shouldJump = false;
        gM = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        isGameOver = gM.isGameOver;
    }

    private void Update() {
        if (enemyhealth <= 0) {
            dead();
            print("Destroy");
            isGameOver = true;
        }
        if(target.transform.position.x < transform.position.x) {
            transform.localScale = new(1, 1);
        }
        else if(target.transform.position.x > transform.position.x) {
            transform.localScale = new(-1, 1);
        }
    }

    private void FixedUpdate() {
        float dist = Vector2.Distance(transform.position,target.transform.position);        
        if (dist <= agroRange) {
            StartChasing();
        }
      
        if(shouldJump == true) {
            enemyRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }        
    }

    void StartChasing() {
        enemyRb.velocity = new Vector2(enemySpeed, 0);
        //enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed * Time.fixedDeltaTime);
    }

    void dead() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            Debug.Log("collided with Platform");
            shouldJump = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            shouldJump = false;
        }
    }


    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Bullet")) {
            enemyhealth -= 1;
            Destroy(collision.gameObject);
            print("Hit");
        }
    }

}
