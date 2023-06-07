using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Heavy : Enemy {

    private void Start() {
        enemyRb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("Game_Manager").GetComponent<GameManager>();
        target = GameObject.Find("Player");
        meleeDetect = GetComponentInChildren<CapsuleCollider2D>();

    }

    void attack() {
        //play animation
        //StartAttackingCoroutine
        //damage Player
    }




}
