using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    private Rigidbody2D playerRb;
    private GameManager gameManager;
    public float runSpeed , jumpForce;
    public int direction;
    private bool isGrounded,isHolding,shouldJump;

    public GameObject bullet, shootPos;

    void Start() {
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        playerRb = GetComponent<Rigidbody2D>();
        direction = 1;  
    }

    void FixedUpdate() {
        if(isHolding == true && isGrounded == false) {
            playerRb.AddForce(new Vector2(direction,0) * runSpeed/2 * Time.fixedDeltaTime, ForceMode2D.Force);
        }
        if(isHolding == true && isGrounded == true) {
            playerRb.AddForce(new Vector2(direction, 0) * runSpeed * Time.fixedDeltaTime, ForceMode2D.Force);
        }

        if (isGrounded == true && shouldJump == true) {
            playerRb.AddForce(Vector2.up * jumpForce * Time.fixedDeltaTime, ForceMode2D.Impulse);
            isGrounded = false;
            shouldJump = false;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision) {
        //isGrounded = true;
        if (collision.gameObject.CompareTag("Enemy")) {
            Debug.Log("Collision:Enemy");
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Platform")) {
            isGrounded = true;
        }
        else if (collision.gameObject.CompareTag("Wall"))
        {
            isGrounded = true;
        }

        if (collision.gameObject.CompareTag("PowerUp")) {
            Debug.Log("Collision:PowerUp");
            StartCoroutine(shortPowerUp());
            Destroy(collision.gameObject);
        }
    }

    public void OnButtonShoot() {
        Instantiate(bullet, shootPos.transform.position, Quaternion.identity);
    }

    public void OnLeftDown() {
      
        isHolding = true;
        direction = -1;
        transform.localScale = new (-1, 1);
    }

    public void onLeftUp() {
        isHolding = false;
    }

    public void onRightDown() {
        isHolding = true;
        direction = 1;
        transform.localScale = new Vector3(1, 1);
    }

    public void onRightUp() {
        isHolding = false;
    }

    public void onClickJump() {
        shouldJump = true;
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

    public int direction_Facing() {
        if (direction == 1)
        {
            return 1;
        }
        else if (direction == -1)
        {
            return -1;
        }
        else {
            return 0;
        }
    }
}
