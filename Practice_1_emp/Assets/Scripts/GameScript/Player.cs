using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    int currentHealth,maxHealth = 100;
    private GameManager gameManager;
    public HealthBar healthBar;

    private void Start() {
        currentHealth = maxHealth;
        healthBar.MaxHealth(maxHealth);
    }

    public void DamageTaken(int damage) {
        currentHealth = currentHealth - damage;
        healthBar.SetHealth(currentHealth);

        if (currentHealth <= 0) {
            gameManager.isGameOver = true;
        }
    }
}
