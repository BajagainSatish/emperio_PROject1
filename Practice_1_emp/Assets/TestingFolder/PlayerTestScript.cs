using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTestScript : MonoBehaviour {

    Rigidbody2D playerRb;
    SpriteRenderer sp;
    GameManager gameManager;
    public GameObject bullet, shootPos;

    public float runSpeed, jumpForce,hangTime, fallMultiplyer;
    float hangCounter;
    

    int direction;

    bool isGrounded, isHolding,shortJump;

    public Transform camTarget;
    public float aheadAmount, aheadSpeed;

    void Start() {
        direction = 0;
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        sp = GameObject.Find("PlayerSprite").GetComponent<SpriteRenderer>();
        if(sp == null) {
            print("didnt found shit");
        }
        direction = 1;
    }

    void FixedUpdate() {

        if (isHolding == true && isGrounded == true) {
            playerRb.AddForce(new Vector2(direction, 0) * runSpeed * Time.fixedDeltaTime, ForceMode2D.Force); // Walking in Ground
        }
        else if (isHolding == true && isGrounded == false) {
            playerRb.AddForce(new Vector2(direction, 0) * runSpeed / 2 * Time.fixedDeltaTime, ForceMode2D.Force); // Walking When in Air/Juming
        }

        if (isGrounded == true) { // Cayoti Time/ HangTime
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
            camTarget.localPosition = new Vector2(Mathf.Lerp(camTarget.localPosition.x, aheadAmount * direction, aheadSpeed * Time.deltaTime), camTarget.localPosition.y);
        }

    }

    public void onJumpButtonDown() { // When jump button is pressed 
        if (isGrounded == true && hangCounter > 0 ) { 
            playerRb.velocity = new Vector2(playerRb.velocity.x, jumpForce);
            isGrounded = false;
            shortJump = false;
        }
    }
     
    public void onJumpButtonUp() { // When jump button is released
        if(playerRb.velocity.y > 0) {  
            playerRb.velocity = new Vector2(playerRb.velocity.x, playerRb.velocity.y * .5f );
            shortJump = true;
        }
    }
    
    public void OnLeftDown() { // When button is pressed 
        isHolding = true; 
        direction = -1;
        sp.flipX = true;
        //transform.localScale = new(-1, 1);
    }

    public void onLeftUp() { //When button is released
        isHolding = false;
        direction = 0;
    }

    public void onRightDown() { // When button is pressed 
        isHolding = true;
        direction = 1;
        sp.flipX = false;
       // transform.localScale = new (1, 1);     
    }

    public void onRightUp() { //When button is released
        isHolding = false;
        direction = 0;
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

    private void OnCollisionEnter2D(Collision2D collision) {
        //isGrounded = true;
        if (collision.gameObject.CompareTag("Enemy")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
            //playerRb.velocity = Vector2.zero; // after fall when player hits ground velocity will be zero instantly
        }
        else if (collision.gameObject.CompareTag("Platform")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Wall")) {
            isGrounded = true;
        }
    }
}