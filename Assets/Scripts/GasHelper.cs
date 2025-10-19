using System;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;

public class GasHelper : MonoBehaviour
{
    public int roomNum;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void OnMouseDown()
    {
        GameManager.Instance.Room = roomNum;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameManager.Instance.AddToRooms(collision.gameObject.GetComponent<Human>(), roomNum);
    }
}
