using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public static PlayerHealth instance;
    [SerializeField] private int maxHealth = 100;
    [SerializeField] private int currentHealth;
    [SerializeField] public int enemyKilled;
    [SerializeField] private GameObject healthText;
    [SerializeField] private GameObject enemyKilledText;

    private void Start()
    {
        currentHealth = maxHealth;
        enemyKilled = 0;
    }

    private void Update()
    {
        healthText.GetComponent<TextMeshProUGUI>().text = "Health : " + currentHealth;
        enemyKilledText.GetComponent<TextMeshProUGUI>().text = "Enemy Killed : " + enemyKilled;
    }

    public void TakeDamage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ghost"))
        {
            TakeDamage(10);
            Destroy(other.gameObject);
            Debug.Log("enemyhit");
        }
    }

    private void Die()
    {
        // You can implement death logic here, such as showing a game over screen, respawning, etc.
        // For example, you can reload the current scene or show a game over panel.
        Debug.Log("Player died.");
    }
}
