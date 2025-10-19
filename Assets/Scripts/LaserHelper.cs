using UnityEngine;
using UnityEngine.EventSystems;

public class LaserHelper : MonoBehaviour, IPointerClickHandler
{
    public int roomNum;
    public void OnPointerClick(PointerEventData eventData)
    {
        Debug.Log("onmousedown laserhelper");
        GameManager.Instance.Room = roomNum;
        PowerUpBar.Instance.UseLaser();
    }

}
