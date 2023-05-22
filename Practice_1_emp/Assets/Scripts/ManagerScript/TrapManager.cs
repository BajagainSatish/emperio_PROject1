using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapManager : MonoBehaviour
{
    GameObject player;
    GameObject[] trap;

    public int detectRange,rotateSpeed;
    public float distance;

    void Start(){
        player = GameObject.Find("Player");
        trap = GameObject.FindGameObjectsWithTag("Trap1");
        trap[0].SetActive(false);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        foreach (GameObject obj in trap) {
            distance = Vector2.Distance(player.transform.position, obj.transform.position);

            if (distance <= detectRange) {
                obj.transform.Rotate(Vector3.forward * Time.fixedDeltaTime * rotateSpeed);
            }
        }
        
    }
}
