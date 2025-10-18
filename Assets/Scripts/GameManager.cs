using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public GameObject gameOverPanel;

    // private void Awake()
    // {
    //     Instance = this;
    // }
    
    public void TriggerGameOver()
    {
        Time.timeScale = 0;

        if(gameOverPanel != null)
        {
            gameOverPanel.SetActive(true);
        }
    }
    
}