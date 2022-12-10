using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private GameManager gm;
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpUpForce;
    private bool isChasing;
    public GameObject target;
    private Rigidbody2D enemyRb;

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }

    private void Update() {
        StartCoroutine(WaitBeforeFollowPlayer());

        if (isChasing == true) {
            enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed,ForceMode2D.Force);
            Debug.Log("Chasing");
        }
    }

    private IEnumerator WaitBeforeFollowPlayer() {
        yield return new WaitForSeconds(2);
        isChasing = true;
      
    }

    private void OnTriggerEnter2D(Collider2D other) {

    }

    private void OnTriggerStay2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            isChasing = false;
            enemyRb.AddForce(new Vector2(0, jumpUpForce));

        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            isChasing = true;
        }
    }
}
