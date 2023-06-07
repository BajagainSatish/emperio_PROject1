using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    [SerializeField] protected float jumpForce, speed, agroRange,dist;
    [SerializeField] protected int health = 100;

    protected GameObject target;
    protected Collider2D meleeDetect;
    protected GameManager gameManager;
    protected Rigidbody2D enemyRb;

    bool shouldJump, shouldChase = true;

    private void Start() {
        health = 100;
        enemyRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        meleeDetect = GetComponentInChildren<CapsuleCollider2D>();
        if (target == null) {
            Debug.Log("Not Found");
        }
        else {
            Debug.Log("Found");
        }
    }

    private void Update() {
        if (health <= 0) {
            dead();
        }
        if(target.transform.position.x < transform.position.x) {
            transform.localScale = new(1, 1);
        }
        else if(target.transform.position.x > transform.position.x) {
            transform.localScale = new(-1, 1);
        }
        dist = Vector2.Distance(transform.position, target.transform.position);

    }

    private void FixedUpdate() {
        if (dist <= agroRange) {
            StartChasing();
            print("Chase");
        }

        if(shouldJump == true) {
            enemyRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }        
    }

    void StartChasing() {
        if (shouldChase == true) {
            enemyRb.velocity = new Vector2(speed, 0);
        }
        //enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collider) {
 
        if (collider.gameObject.CompareTag("Platform")) {
            shouldJump = true;
        }
        if (collider == meleeDetect) {
            print("Working?");
        }

        /*
        if (collider.gameObject.CompareTag("Player")) {
            timer += Time.deltaTime;
            shouldChase = false;

            Player player = collider.gameObject.GetComponent<Player>();
            player.DamageTaken(damage);
            timer = 0;
            Debug.Log("Inside If statement");    
        }
        */

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
            health -= 1;
            Destroy(collision.gameObject);//destroy Bullet
        }
    }

    void dead() {
        Destroy(gameObject);
    }


}
