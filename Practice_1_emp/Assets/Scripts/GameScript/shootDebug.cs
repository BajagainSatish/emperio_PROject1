using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class shootDebug : MonoBehaviour
{
    public GameObject shootPos;
    public GameObject playerSprite;

    //This piece of code changes position of the shootposition as the player flips along X axis.

    public void leftMovement()
    {
       transform.position = playerSprite.transform.position + new Vector3(-1.59f, 0.28f, 0f);
       //transform.position = playerSprite.transform.position
    }
    public void rightMovement()
    {
        //Debug.Log("Right_deudedue");
        transform.position = playerSprite.transform.position + new Vector3(1.59f, 0.28f, 0f);
    }
}
