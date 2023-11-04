using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 5.0f;
    public int damageAmount = 10;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform ghostModel;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ghostModel = transform.Find("Armature_Halloween");
        
        ghostModel.LookAt(player.transform);
        ghostModel.transform.Rotate(-90,0,0);
    }

    private void Update()
    {
        if (player != null)
        {
            // Calculate the direction from the enemy to the player
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Normalize the direction vector to maintain constant speed
            directionToPlayer.Normalize();

            // Move the enemy towards the player
            transform.Translate(directionToPlayer * moveSpeed * Time.deltaTime);
        }
    }

   /* private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Weapon"))
        {
            Destroy(gameObject);
        }
    }*/
}
