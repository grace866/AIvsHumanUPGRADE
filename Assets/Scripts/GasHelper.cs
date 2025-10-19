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
}
