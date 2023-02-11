using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    Rigidbody2D playerRb;
    GameObject playerSprite;
    GameManager gameManager;
    public GameObject bullet, shootPos;


    public float runSpeed, jumpForce, hangTime, fallMultiplyer;
    float hangCounter;

    public int direction;

    bool isGrounded, isHolding, shortJump;

    public Transform camTarget;
    public float aheadAmount, aheadSpeed;
    //public shootDebug shootdebug;

    void Start() {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        playerSprite = GameObject.Find("Player_Sprite");
        direction = 1;
    }

    void FixedUpdate() {

        if (isHolding == true && isGrounded == true) {
            playerRb.AddForce(new Vector2(direction, 0) * runSpeed * Time.fixedDeltaTime, ForceMode2D.Force); // Walking in Ground
        }
        else if (isHolding == true && isGrounded == false) {
            playerRb.AddForce(new Vector2(direction, 0) * runSpeed / 2 * Time.fixedDeltaTime, ForceMode2D.Force); // Walking When in Air/Juming
        }

        if (isGrounded == true) { // Coyoti Time HangTime
            hangCounter = hangTime;
        }
        else {
            hangCounter -= Time.deltaTime;
        }

        if (playerRb.velocity.y < 0 && isGrounded == false && shortJump == true) {
            playerRb.gravityScale = playerRb.gravityScale * fallMultiplyer; // Increase fall speed
        }
        else {
            playerRb.gravityScale = 3;
        }
        // Move Camera Point  
        if (direction != 0 && playerRb.velocity.x != 0) {
                camTarget.localPosition = new Vector2(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * direction, aheadSpeed * Time.deltaTime),
                    camTarget.localPosition.y);
        }

    }

    public void onJumpButtonDown() { // When jump button is pressed 
        if (isGrounded == true && hangCounter > 0) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isGrounded = false;
            shortJump = false;
        }
    }

    public void onJumpButtonUp() { // When jump button is released
        if (playerRb.velocity.y > 0) {
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * .5f);
            shortJump = true;
        }
    }

    public void onRightDown() { // When button is pressed 
        isHolding = true;
        direction = 1;
        //sp.flipX = false;
        playerSprite.transform.localScale = new Vector2(1, 1);
        shootPos.transform.position = transform.position + new Vector3(2f, 2f, 0f);
    }

    public void onRightUp() { //When button is released
        isHolding = false;
    }

    public void OnLeftDown() { // When button is pressed 
        isHolding = true;
        direction = -1;
        //sp.flipX = true;
        playerSprite.transform.localScale = new Vector2(-1, 1);
        shootPos.transform.position = transform.position + new Vector3(-2f, 2f, 0f);
    }

    public void onLeftUp() { //When button is released
        isHolding = false;
    }



    public int direction_Facing() {
        if (direction == 1) {
            return 1;
        }
        else if (direction == -1) {
            return -1;
        }
        else {
            return 0;
        }
    }
    public void OnButtonShoot() {
        Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
        Debug.Log("shoot");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Enemy")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;      
        }
        else if (collision.gameObject.CompareTag("Platform")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Wall")) {
            isGrounded = true;
        }
    }
}
