using System.Collections.Generic;
using System;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject gameOverPanel;
    public Boolean GasActivated;
    public int Room;
    private Dictionary<int, List<Human>> Rooms;

    // Game state management
    private bool isGameOver = false;
    private bool hasGameOverPanelShown = false;

    private void Awake()
    {
        Instance = this;
        Room = 0;
        
        // Ensure game over panel starts hidden
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }
    
    public void TriggerGameOver()
    {
        // Prevent multiple game over triggers
        if (isGameOver || hasGameOverPanelShown)
            return;
            
        isGameOver = true;
        hasGameOverPanelShown = true;
        
        // Pause the game
        Time.timeScale = 0;

        // Show the game over panel
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
        
        Debug.Log("Game Over!");
    }
    
    // Method to check if game is over
    public bool IsGameOver()
    {
        return isGameOver;
    }
    
    // Method to reset game state (useful for restart functionality)
    public void ResetGame()
    {
        isGameOver = false;
        hasGameOverPanelShown = false;
        Time.timeScale = 1;
        
        if (gameOverPanel != null)
        {
            gameOverPanel.SetActive(false);
        }
    }

    public void Update()
    {
        if (GasActivated && Room != 0)
        {
            foreach (Human h in Rooms[Room])
            {
                Destroy(h);
            }
        }
    }
}