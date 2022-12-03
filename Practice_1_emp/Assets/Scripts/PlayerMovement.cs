using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D playerRb;
    private GameManager gameManager;
    public float speed = 10;

    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    { 
        //playerRb.velocity = new Vector2(Input.GetAxis("Horizontal") * (speed / 2), playerRb.velocity.y);
        if (Input.GetKey(KeyCode.Space)) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, speed);
            Debug.Log("Jump");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy")) {
            Destroy(collision.gameObject);
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
        playerRb.AddForce(Vector2.up * speed, ForceMode2D.Force);
    }
}
