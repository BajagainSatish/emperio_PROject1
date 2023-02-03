using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Transform target;

    private void Update()
    {
        transform.position = new Vector3(target.position.x, target.position.y, target.position.z);
         
        
        if (target.position.x < -8.11f && target.position.y < -1.2f) {
            transform.position = new Vector3(-8.11f,-1.2f,transform.position.z);
            //Debug.Log("up&down");
        }
        else if (target.position.y < -1.2f) {
            transform.position = new Vector3(target.position.x,-1.2f,transform.position.z);
            //Debug.Log("just up");
        }
        else if (target.position.x < -8.11f)
        {
            transform.position = new Vector3(-8.11f, target.position.y, transform.position.z);
            //Debug.Log("just left");
        }

        
    }
}
