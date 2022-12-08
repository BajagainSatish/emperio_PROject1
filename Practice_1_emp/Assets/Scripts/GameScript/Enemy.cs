using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    [SerializeField] private float jumpSpeed;
    public Transform target;
    //public Transform obstacleTarget; //drag obstacle prefab into script
    private Rigidbody2D enemyRb;
    //public float minimumDistance; //10, distance between enemy and obstacle at which enemy jumps

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
    }

    private void Update() {
        StartCoroutine(WaitBeforeFollowPlayer());
        /*
        if (Vector2.Distance(transform.position, obstacleTarget.position) < minimumDistance) {
            //Debug.Log("collided with obstacle");
            enemyRb.AddForce(Vector2.up * jumpSpeed, ForceMode2D.Force);
        }
        */
    }

    private IEnumerator WaitBeforeFollowPlayer() {
        yield return new WaitForSeconds(2);
        enemyRb.AddForce((target.transform.position - transform.position).normalized * enemySpeed);
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Platform")) {
            //Debug.Log("collided with obstacle");
            enemyRb.AddForce(Vector2.up*jumpSpeed,ForceMode2D.Force);
        }
    }

}
