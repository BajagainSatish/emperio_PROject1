using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRb;
    private GameManager gameManager;

    public float runSpeed, jumpForce;
    private int direction;

    private bool isGrounded,isHolding,shouldJump;
   

    void Start() {
        playerRb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate() {
        if(isHolding == true &&  isGrounded == true) {
            playerRb.AddForce(new Vector2(direction,0) * runSpeed * Time.fixedDeltaTime);
        }
        if (shouldJump == true && isGrounded == true) {
            playerRb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            shouldJump = false;
            isGrounded = false;   
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
    }

    public void OnLeftUp() {
        isHolding = false;
    }

    public void OnRightDown() {
        isHolding = true;
        direction = 1;
    }

    public void OnRightUp() {
        isHolding = false;
    }


    public void OnClickJump() {
        shouldJump = true;
    }

    private IEnumerator shortPowerUp() {
        runSpeed *= 2;
        jumpForce *= 2;
        yield return new WaitForSeconds(10);
        runSpeed /= 2;
        jumpForce /= 2;
        StopCoroutine(shortPowerUp());
    }


}
