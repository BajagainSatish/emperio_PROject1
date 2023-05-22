using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Fast : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpForce;
    public GameObject target;
    Rigidbody2D enemyRb;
    bool shouldMove, shouldJump;

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
        shouldMove = true;
        shouldJump = false;
    }

    private void FixedUpdate() {
        StartCoroutine(WaitBeforeFollowPlayer());
        if (shouldMove == true) {
            enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed * Time.fixedDeltaTime);
            Debug.Log("Shold Move");
        }

        if (shouldJump == true) {
            enemyRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            shouldJump = false;
        }

    }

    private IEnumerator WaitBeforeFollowPlayer() {
        yield return new WaitForSeconds(2);
        shouldMove = true;

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
