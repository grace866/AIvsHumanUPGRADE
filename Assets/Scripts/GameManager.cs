using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject gameOverPanel;
    
    // Game state management
    private bool isGameOver = false;
    private bool hasGameOverPanelShown = false;

    private void Awake()
    {
        Instance = this;
        
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
}