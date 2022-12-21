using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Heavy : MonoBehaviour {

    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpForce;
    public float agroRange;
    public int enemyhealth;
    public GameObject target;
    private Rigidbody2D enemyRb;
    bool shouldJump, shouldchase;

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
        shouldJump = false;
    }

    private void FixedUpdate() {
        float dist = Vector2.Distance(transform.position, target.transform.position);
        if (dist <= agroRange) {
            shouldchase = true;
            enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed * Time.fixedDeltaTime);
        }

        if (shouldchase == false) {
            StartPetrol();
        }

        if (shouldJump == true) {
            enemyRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }

        if (enemyhealth <= 0) {
            dead();
        }

    }

    void dead() {
        Destroy(gameObject);
    }

    void StartPetrol() {
        //Will Start Petroling in certain Location.
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


}
