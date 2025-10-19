using UnityEngine;
using UnityEngine.SceneManagement;

public class OpeningScene1 : MonoBehaviour
{
    public GameObject instructionsPanel;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (instructionsPanel != null)
        {
            instructionsPanel.SetActive(false);
        }

    }

    public void StartGame()
    {
        SceneManager.LoadScene("LayoutScene");
    }

    public void ShowInstructions()
    {
        instructionsPanel.SetActive(true);
    }

    public void CloseInstructions()
    {
        instructionsPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
