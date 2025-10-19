using System;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class GasHelper : MonoBehaviour, IPointerClickHandler
{
    public int roomNum;
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onmousedown gashelper");
        GameManager.Instance.Room = roomNum;
        PowerUpBar.Instance.UsePowerUp();
    }
}
