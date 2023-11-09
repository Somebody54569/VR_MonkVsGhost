using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    private int currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    private void Update()
    {
        transform.position = new Vector3(transform.position.x, 1.1f, transform.position.z);
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
        }
    }

    private void Die()
    {
        // You can implement death logic here, such as showing a game over screen, respawning, etc.
        // For example, you can reload the current scene or show a game over panel.
        Debug.Log("Player died.");
    }
}
