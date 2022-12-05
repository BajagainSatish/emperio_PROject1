using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private float cameraSpeed;

    private void Update()
    {
        transform.position = new Vector3(player.position.x, player.position.y, transform.position.z);
        if (player.position.x < -8.11f && player.position.y < -1.2f) {
            transform.position = new Vector3(-8.11f,-1.2f,transform.position.z);
            //Debug.Log("up&down");
        }
        else if (player.position.y < -1.2f) {
            transform.position = new Vector3(player.position.x,-1.2f,transform.position.z);
            //Debug.Log("just up");
        }
        else if (player.position.x < -8.11f)
        {
            transform.position = new Vector3(-8.11f, player.position.y, transform.position.z);
            //Debug.Log("just left");
        }
    }
}
