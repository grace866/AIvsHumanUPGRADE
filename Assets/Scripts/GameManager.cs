using System.Collections.Generic;
using System;
using UnityEngine;
using Unity.VisualScripting;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }

    public Boolean GasActivated;
    public int Room;
    //public int originalSpeed = 2;
    private Dictionary<int, List<Human>> Rooms;
    private int gasDuration = 30;

    // Game state management
    private bool isGameOver = false;

    private Coroutine gasEffectCoroutine;
    public float GasDuration = 30f;
    private void Awake()
    {
        Instance = this;
        Room = 0;
        Rooms = new Dictionary<int, List<Human>>();
    }
    
    public void TriggerGameOver()
    {
        // Prevent multiple game over triggers
        if (isGameOver)
            return;
            
        isGameOver = true;
        
        // Pause the game
        Time.timeScale = 0;

        // Go to game over scene
        SceneManager.LoadScene("GameOverScene");
        
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
        Time.timeScale = 1;
        // Go to layout scene
        SceneManager.LoadScene("LayoutScene");
    }

    public void AddToRooms(Human h, int room)
    {
        if (!Rooms.ContainsKey(room)) Rooms.Add(room, new List<Human>());
        Rooms[room].Add(h);
    }

    public void ActivateGas()
    {
        GasActivated = true;
        Debug.Log("activated gas");
        // gas action
        if (GasActivated && Room != 0)
        {
            gasEffectCoroutine = StartCoroutine(ApplyGasEffect(Room));
        }

    }

    private IEnumerator ApplyGasEffect(int room)
    {
        Debug.Log("in coroutine");
        List<Human> modifiedHumans = new List<Human>();

        if (Rooms.ContainsKey(room))
        {
            foreach (Human h in Rooms[room])
            {
                Debug.Log("human");
                modifiedHumans.Add(h);
                h.GetComponent<NavMeshAgent>().speed /= 10;
            }

            yield return new WaitForSeconds(gasDuration);

            foreach(Human h in modifiedHumans)
            {
                h.GetComponent <NavMeshAgent>().speed *= 10;
            }
        }
        GasActivated = false;
        gasEffectCoroutine = null;
    }

    public void Update()
    {
        // gas action
        
    }


}