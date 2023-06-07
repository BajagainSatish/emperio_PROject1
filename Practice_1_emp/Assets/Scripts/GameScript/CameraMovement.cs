using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;
    public float xLimit;
    public float yLimit;

    private void Update()
    {
        //transform.position = new Vector2(target.position.x, target.position.y);
         
        
        if (target.position.x < xLimit && target.position.y < yLimit) {
            transform.position = new Vector2(-8.11f,-1.2f);
        }
        else if (target.position.y < -1.2f) {
            transform.position = new Vector2(target.position.x,-1.2f);
        }
        else if (target.position.x < -8.11f)
        {
            transform.position = new Vector2(-8.11f, target.position.y);
        }
    }
}
