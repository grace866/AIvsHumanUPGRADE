using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

public class PowerUpBar : MonoBehaviour
{
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

    void Start()
    {
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

    public bool TryUsePowerUp(float amount)
    {
        if (currentValue >= amount)
        {
            currentValue -= amount;
            UpdateBarUI();
            panel.SetActive(true);
            return true;
        }
        return false;
    }

    private void UpdateBarUI()
    {
        slider.value = currentValue;
    }
}