using System;
using System.Collections.Generic;
//using NUnit.Framework;
using UnityEngine;
using UnityEngine.EventSystems;

public class GasHelper : MonoBehaviour, IPointerClickHandler
{
    public int roomNum;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onmousedown gashelper");
        GameManager.Instance.Room = roomNum;
        GameObject gasObject = GameObject.FindWithTag("GasSystem");
        gasObject.GetComponent<PowerUpBar>().UseGas();
    }
}
