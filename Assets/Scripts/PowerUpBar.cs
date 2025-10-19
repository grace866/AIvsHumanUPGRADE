using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

public class PowerUpBar : MonoBehaviour
{
    public static PowerUpBar Instance { get; private set; }

    // the slider is the UI element that displays the resource bar, drag the ui component here in inspector
    public Slider slider;
    public string powerup;
    public Button button;
    public GameObject panel; // set active or inactive
    
    public float maxValue = 100f;
    // regeneration rate of powerup, variable based on the powerup
    public float regenerationRate;

    // current recharge rate of powerup    
    private float currentValue;

    void Awake()
    {
        Instance = this;
        // Each resource starts at the max value.
        currentValue = 0f;
        slider.maxValue = maxValue;
        slider.value = currentValue;
        panel.SetActive(true);
    }

    void Update()
    {
        if (currentValue < maxValue && regenerationRate > 0)
        {
            currentValue += regenerationRate * Time.deltaTime;

            // Ensure the value doesn't exceed the max value.
            currentValue = Mathf.Min(currentValue, maxValue);
            UpdateBarUI();
        }
        if (currentValue == maxValue)
        {
            panel.SetActive(false);
        }
        else
        {
            panel.SetActive(true);
        }
    }

    public void UseGas() // need to change to useGas
    {
        Debug.Log("using power up in powerupbar");
        GameManager.Instance.ActivateGas();
        currentValue = 0f;
        UpdateBarUI();
        panel.SetActive(true);
        //if (currentValue >= amount)
        //{
        //    currentValue -= amount;
        //    UpdateBarUI();
        //    panel.SetActive(true);
        //    return true;
        //}
        //return false;
    }

    public void UseLaser()
    {
        GameManager.Instance.ActivateLaser();
        currentValue = 0f;
        UpdateBarUI();
        panel.SetActive(true);
    }

    private void UpdateBarUI()
    {
        slider.value = currentValue;
    }
}