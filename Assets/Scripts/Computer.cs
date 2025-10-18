using UnityEngine;

public class Computer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        if (other.gameObject.CompareTag("Human"))
        {
            GameManager.Instance.TriggerGameOver();
        }
    }
}