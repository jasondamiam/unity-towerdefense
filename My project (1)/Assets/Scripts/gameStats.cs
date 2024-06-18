using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class gameStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    public Health healthBar;

    public GameObject PausePanel, TowerSelector, MoneyScreen, HealthBar, GameOver;

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }

    public void MinusHealth(float amount)
    {
        currentHealth -= amount;
        healthBar.SetSlider(currentHealth);
    }
    private void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = maxHealth;
        }
        if(currentHealth <= 0)
        {
            Death();
        }
    }

    public void Death()
    {
        PausePanel.SetActive(false);
        TowerSelector.SetActive(false);
        MoneyScreen.SetActive(false);
        HealthBar.SetActive(false);
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}