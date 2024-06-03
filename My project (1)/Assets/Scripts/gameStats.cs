using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameStats : MonoBehaviour
{
    [SerializeField] private float maxHealth;

    private float currentHealth;

    public Health healthBar;

    private void Start()
    {
        currentHealth = maxHealth;

        healthBar.SetSliderMax(maxHealth);
    }
}