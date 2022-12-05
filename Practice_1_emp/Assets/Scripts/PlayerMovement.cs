using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    public float speed;
    private bool isGrounded;

    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update()
    { 
        //playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed / 2), playerRb.velocity.y);
        if (Input.GetKey(KeyCode.Space) && isGrounded) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, speed);
            Debug.Log("Jump");
            isGrounded = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision:Enemy");
        }
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            Debug.Log("Player:Grounded");
        }
    }

    public void onClickLeft()
    {
        playerRb.AddForce(Vector2.left * speed, ForceMode2D.Force);
    }
    public void onClickRight()
    {
        playerRb.AddForce(Vector2.right * speed, ForceMode2D.Force);
    }
    public void OnClickJump()
    {
        if (isGrounded == true)
        {
            playerRb.AddForce(Vector2.up * speed, ForceMode2D.Force);
            isGrounded = false;
            Debug.Log("Jump");
        }
    }
}
