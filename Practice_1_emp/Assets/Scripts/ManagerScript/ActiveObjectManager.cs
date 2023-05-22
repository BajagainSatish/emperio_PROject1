using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveObjectManager : MonoBehaviour
{
    public GameObject[] objectsToControl;
    GameObject player;
    public float distance,detectRange = 15f;


    private void Start() {
        player = GameObject.Find("Player");
    }

    private void Update() {
        foreach (GameObject obj in objectsToControl) {
            distance = Vector2.Distance(player.transform.position, obj.transform.position);
              
            if (distance <= detectRange) { 
                obj.SetActive(true);
            }

            if (distance > detectRange) {
                obj.SetActive(false);
            }
        }
    }

}
