using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpSpeed;
    public Transform target;
    private Rigidbody2D enemyRb;

    private void Update() {
        StartCoroutine(WaitBeforeFollowPlayer());
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private IEnumerator WaitBeforeFollowPlayer() {
        yield return new WaitForSeconds(2);
        transform.position = Vector2.MoveTowards(transform.position,target.position,enemySpeed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Obstacle")) {
            //Debug.Log("collided with obstacle");
            enemyRb.AddForce(Vector2.up*jumpSpeed,ForceMode2D.Force);
        }
    }
}
