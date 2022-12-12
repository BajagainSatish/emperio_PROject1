using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpForce;
    public GameObject target;
    private Rigidbody2D enemyRb;

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        StartCoroutine(WaitBeforeFollowPlayer());
    }

    private IEnumerator WaitBeforeFollowPlayer() {
        yield return new WaitForSeconds(2);
        enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("Platform")) {
            Debug.Log("collided with Platform");
            enemyRb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
            //enemyRb.AddForce(Vector2.up * jumpForce * 500, ForceMode2D.Force);
        }
    }

}
