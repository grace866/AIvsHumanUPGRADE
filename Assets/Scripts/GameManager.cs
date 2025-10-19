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
    private Boolean InWinScene = false;
    public Boolean LaserActivated;
    public int Room;
    public float originalSpeed = 0.5f;
    private Dictionary<int, List<Human>> Rooms;

    // Game state management
    private bool isGameOver = false;

    private Coroutine gasEffectCoroutine;
    public float GasDuration = 0.5f;

    private void Awake()
    {
        Instance = this;
        Room = 0;
        Rooms = new Dictionary<int, List<Human>>();
        DontDestroyOnLoad(gameObject);
    }

    public void TriggerGameOver()
    {
        InWinScene = true;
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

    public void RemoveFromRoom(Human human, int room)
    {
        if (Rooms.ContainsKey(room) && Rooms[room] != null) Rooms[room].Remove(human);
        if (Rooms.ContainsKey(room) && Rooms[room].Count == 0) Rooms.Remove(room);
    } 

    public void SetGasActivated(bool gasActivated)
    {
        GasActivated = gasActivated;
    }

    public void SetLaserActivated(bool laserActivated)
    {
        LaserActivated = laserActivated;
        Debug.Log("laser activated");
    }

    public void ActivateLaser()
    {
        Debug.Log("in activate laser");
        LaserActivated = true;
        if (LaserActivated && Room != 0)
        {
            foreach (Human h in Rooms[Room])
            {
                Debug.Log("in loop");
                h.Die();
                h.GetComponent<NavMeshAgent>().speed = 0;
                //Rooms[Room].Remove(h);
                //Destroy(h);
                //animator.GetComponent<Animator>().SetBool("isDead", true);
            }
            Rooms.Remove(Room);
            foreach (int r in Rooms.Keys)
            {
                Debug.Log(r);
                Debug.Log(Rooms[r].Count);
            }
        }
    }

    private IEnumerator switchToWinScene()
    {
        InWinScene = true;
        yield return new WaitForSecondsRealtime(1f);
        SceneManager.LoadScene("WinScene");
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
        foreach (int r in Rooms.Keys)
        {
            Debug.Log(r);
            Debug.Log(Rooms[r].Count);
        }
        List<Human> modifiedHumans = new List<Human>();

        if (Rooms.ContainsKey(room))
        {
            foreach (Human h in Rooms[room])
            {
                Debug.Log("human speed: " + h.GetComponent<NavMeshAgent>().speed);
                modifiedHumans.Add(h);
                h.GetComponent<NavMeshAgent>().speed = originalSpeed / 10;
                Debug.Log("human speed: " + h.GetComponent<NavMeshAgent>().speed);
            }

            Debug.Log("Start wait...");
            Debug.Log("GameManager still active? " + gameObject.activeInHierarchy + " scene: " + SceneManager.GetActiveScene().name);

            yield return new WaitForSecondsRealtime(GasDuration);

            Debug.Log("done waiting");

            foreach(Human h in modifiedHumans)
            {
                Debug.Log("human speed: " + h.GetComponent<NavMeshAgent>().speed);
                h.GetComponent <NavMeshAgent>().speed = originalSpeed;
                Debug.Log("human speed: " + h.GetComponent<NavMeshAgent>().speed);

            }
        }
        GasActivated = false;
        gasEffectCoroutine = null;
        Room = 0;
    }

    public void Update()
    {
        if (Rooms != null && Rooms.Count == 0 && !InWinScene)
        {
            StartCoroutine(switchToWinScene());
        }
    }


}