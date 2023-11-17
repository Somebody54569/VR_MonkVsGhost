using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TimeManager : MonoBehaviour
{
    [SerializeField] float totalTime = 60f;  // Total time for the countdown in seconds
    [SerializeField] float currentTime;      // Current time left
    [SerializeField] bool isGameOver = false; // Flag to track if the game is over

    [SerializeField] TextMeshProUGUI timerText; // Reference to a UI text element to display the countdown
    [SerializeField] GameObject enemySpawner;
    [SerializeField] GameObject endGamePanel;
    void Start()
    {
        currentTime = totalTime; // Initialize the current time to the total time
        UpdateTimerText();       // Update the UI text to show the initial time
    }

    void Update()
    {
        if (!isGameOver)
        {
            // Update the current time based on Time.deltaTime
            currentTime -= Time.deltaTime;

            // Check if time is over
            if (currentTime <= 0f)
            {
                currentTime = 0f; // Ensure the time doesn't go below zero
                isGameOver = true;
                EndGame(); // Call a function to handle game over
            }

            // Update the UI text to show the remaining time
            UpdateTimerText();
        }
    }

    void UpdateTimerText()
    {
        // Display the time in the format MM:SS
        string minutes = Mathf.Floor(currentTime / 60).ToString("00");
        string seconds = (currentTime % 60).ToString("00");

        // Update the UI text
        timerText.text = minutes + ":" + seconds;
    }

    void EndGame()
    {
        enemySpawner.SetActive(false);
        endGamePanel.SetActive(true);
        Debug.Log("Game Over!");
    }
}
