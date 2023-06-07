using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crossbow : MonoBehaviour {
    public float detectionRange = 5f;
    private GameObject target;
    float distanceToPlayer;

    //For Aiming....
    public float enemyAimSpeed = 5.0f;
    Quaternion newRotation;
    float orientTransform;
    float orientTarget;


    //For shooting...
    public float FireRate = 1.0f;
    public float NextFire = 1.0f;

    public Transform bulletPoint;
    public GameObject BulletPrefab;
    public float bulletForce = 20f;

    private void Start() {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        distanceToPlayer = Vector3.Distance(transform.position, target.transform.position);

        orientTransform = transform.position.x;
        orientTarget = target.transform.position.x;

        if (distanceToPlayer <= detectionRange && target.transform.position.y < transform.position.y) {
            if (orientTransform > orientTarget) { 
                newRotation = Quaternion.LookRotation(transform.position - target.transform.position, Vector3.up);
            }
            else {
                newRotation = Quaternion.LookRotation(transform.position - target.transform.position, -Vector3.up);
            }

            newRotation.x = 0.0f;
            newRotation.y = 0.0f;

            transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * enemyAimSpeed);
            if (Time.time > NextFire) {
                NextFire = Time.time + FireRate;
                {
                    Shoot();
                }
            }
        }
    }

    public void Shoot() {
        GameObject Bullet = Instantiate(BulletPrefab, bulletPoint.position, bulletPoint.rotation);
        Rigidbody2D rb = Bullet.GetComponent<Rigidbody2D>();
        rb.AddForce(bulletPoint.up * bulletForce * (distanceToPlayer *100) * Time.deltaTime, ForceMode2D.Impulse);
        Destroy(Bullet, 5);
    }

    private void OnDrawGizmos() {
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}









