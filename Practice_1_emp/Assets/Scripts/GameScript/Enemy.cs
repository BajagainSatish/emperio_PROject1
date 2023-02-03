using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpForce;
    public float agroRange;
    public int enemyhealth,damage = 5;
    float timer;

    private GameObject target;
    public Collider2D attackCollider;
    private GameManager gameManager;


    private Rigidbody2D enemyRb;

    bool shouldJump, isGameOver, shouldChase = true;




    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        target = GameObject.Find("Player");
    }

    private void Update() {
        if (enemyhealth <= 0) {
            dead();
            print("Destroy");
            gameManager.isGameOver = true;
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
        if (shouldChase == true) {
            enemyRb.velocity = new Vector2(enemySpeed, 0);
        }
        //enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed * Time.fixedDeltaTime);
    }

    void dead() {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
 
        if (collider.gameObject.CompareTag("Platform")) {
            Debug.Log("Collided with Platform");
            shouldJump = true;
        }

        if (collider.gameObject.CompareTag("Player")) {
            Debug.Log("detected player");
            timer += Time.deltaTime;
            shouldChase = false;

            Player player = collider.gameObject.GetComponent<Player>();
            if (player != null) {
                player.DamageTaken(damage);
                timer = 0;
                Debug.Log("Inside If statement");
                
            }
        }
        else {
            shouldChase = true;
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
        if (collision.gameObject.CompareTag("Player")) {
            collision.gameObject.GetComponent<Player>().DamageTaken(damage);
        }
    }


}
