using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed, bulletBoundary;
    private int direct;
    Rigidbody2D rb;
    private PlayerController playerContScript;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
        playerContScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    private void Update() {
        direct = playerContScript.direction;
    }
    private void FixedUpdate() {
            rb.AddForce(Vector2.right * Time.deltaTime * bulletspeed, ForceMode2D.Impulse);       
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            Destroy(gameObject);
        }
        else if (collision.gameObject.CompareTag("Platform")) {
            Destroy(gameObject);
        }
    }
}
