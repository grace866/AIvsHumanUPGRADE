using UnityEngine;
using UnityEngine.UI;

public class PowerUpBar : MonoBehaviour
{
    // the slider is the UI element that displays the resource bar, drag the ui component here in inspector
    public Slider slider;

    
    public float maxValue = 100f;
    // regeneration rate of powerup, variable based on the powerup
    public float regenerationRate = 2f;

    // current recharge rate of powerup    
    private float currentValue;

    void Start()
    {
        // Each resource starts at the max value.
        currentValue = maxValue;
        slider.maxValue = maxValue;
        slider.value = currentValue;
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
    }

    public bool TryUsePowerUp(float amount)
    {
        if (currentValue >= amount)
        {
            currentValue -= amount;
            UpdateBarUI();
            return true;
        }
        return false;
    }

    private void UpdateBarUI()
    {
        slider.value = currentValue;
    }
}