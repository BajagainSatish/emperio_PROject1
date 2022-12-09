using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRb;
    private GameManager gameManager;

    public float runSpeed, jumpForce;
    public int direction;

    private bool isGrounded,isHolding;
   

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void Update() {
        if(isHolding == true) {

            playerRb.AddForce(new Vector2(direction,0) * runSpeed, ForceMode2D.Force);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {

        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision:Enemy");
        }

        else if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            Debug.Log("Player:Grounded");
        }
        else if (collision.gameObject.CompareTag("Platform")) {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("PowerUp")) {
            Debug.Log("Collision:PowerUp");
            StartCoroutine(shortPowerUp());
            Destroy(collision.gameObject);
        }
    }


    public void OnLeftDown() {
      
        isHolding = true;
        direction = -1;
        Debug.Log("Is Left Down");
    }

    public void onLeftUp() {
        isHolding = false;
    }

    public void onRightDown() {
        isHolding = true;
        direction = 1;
        Debug.Log("Is Right Down");
    }

    public void onRightUp() {
        isHolding = false;
    }


    public void onClickJump() {
        if (isGrounded == true) {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Force);
            isGrounded = false;
            Debug.Log("Jump");
        }
    }

    private IEnumerator shortPowerUp() {
        runSpeed *= 2;
        jumpForce *= 2;
        yield return new WaitForSeconds(10);
        Debug.Log("YO YO");
        runSpeed /= 2;
        jumpForce /= 2;
        StopCoroutine(shortPowerUp());
    }


}
