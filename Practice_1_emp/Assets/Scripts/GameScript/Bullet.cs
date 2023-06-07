using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletspeed, bulletBoundary;

    private bool shootAlready;
    private int direct;
    public Rigidbody2D rb;
    private PlayerController playerContScript;

    private void Start() {
        shootAlready = false;
        rb = GetComponent<Rigidbody2D>();
        Destroy(gameObject, 5);
        playerContScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }
    
    private void FixedUpdate() {
        direct = PlayerController.direction;
        if (shootAlready == false)
        {
            if (direct == 1)
            {
                rb.AddForce(Vector2.right * Time.deltaTime * bulletspeed, ForceMode2D.Impulse);
                
                shootAlready = true;
            }
            if (direct == -1)
            {
                rb.AddForce(Vector2.left * Time.deltaTime * bulletspeed, ForceMode2D.Impulse);
                shootAlready = true;
            }
        }
        if(rb.velocity.x == 0) {
            Destroy(gameObject);
        }
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
