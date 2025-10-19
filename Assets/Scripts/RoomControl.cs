using UnityEngine;

public class RoomControl : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public int roomNum;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Human"))
        {
            Debug.Log("in a new room " + roomNum);
            Debug.Log(other.gameObject.GetComponent<Human>());
            GameManager.Instance.AddToRooms(other.gameObject.GetComponent<Human>(), roomNum);
        }
    }
}
