using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    private GameObject player;
    private Rigidbody2D playerRb;
    public float xLimit;
    public float yLimit;
    public float aheadAmount, aheadSpeed;

    private void Start() {
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        //transform.position = new Vector2(target.position.x, target.position.y);
         
        
        if (target.position.x < xLimit && target.position.y < yLimit) {
            transform.position = new Vector2(xLimit,-1.2f);
        }
        else if (target.position.y < -1.2f) {
            transform.position = new Vector2(target.position.x,-1.2f);
        }
  
        else if (target.position.x < -8.11f)
        {
            transform.position = new Vector2(-8.11f, target.position.y);
        }

        if (PlayerController.direction != 0 && playerRb.velocity.x != 0) {
            target.localPosition = new Vector2(Mathf.Lerp(target.localPosition.x, aheadAmount * PlayerController.direction, aheadSpeed * Time.deltaTime),
                target.localPosition.y);
        }
    }
}
