using System;
using UnityEngine;

public class Computer : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) 
    {
        print("on trigger entered");
        if (other.gameObject.CompareTag("Human"))
        {
            print("other is human");
            GameManager.Instance.TriggerGameOver();
        }
    }
}