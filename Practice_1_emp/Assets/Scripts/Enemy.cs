using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private float enemySpeed;
    public Transform target;

    private void Update() {
        StartCoroutine(WaitBeforeFollowHero());
    }

    private IEnumerator WaitBeforeFollowHero() {
        yield return new WaitForSeconds(2);
        transform.position = Vector2.MoveTowards(transform.position,target.position,enemySpeed * Time.deltaTime);
    }
}
