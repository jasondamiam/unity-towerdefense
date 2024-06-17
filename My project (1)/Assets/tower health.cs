using System;


using UnityEngine;

public class HealthBar : MonoBehaviour
{
    private static HealthBar _instance;
    private static readonly object _lock = new object();

    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }

    private void Awake()
    {
        lock (_lock)
        {
            if (_instance == null)
            {
                _instance = this;
                MaxHealth = 100;  // Standaard waarde of pas aan naar wens
                CurrentHealth = MaxHealth;
                DontDestroyOnLoad(gameObject);  // Zorg ervoor dat deze niet vernietigd wordt bij het laden van een nieuwe scene
            }
            else
            {
                Destroy(gameObject);  // Vernietig duplicaten
            }
        }
    }

    public static HealthBar GetInstance()
    {
        if (_instance == null)
        {
            GameObject singletonObject = new GameObject();
            _instance = singletonObject.AddComponent<HealthBar>();
            singletonObject.name = typeof(HealthBar).ToString();
        }
        return _instance;
    }

    public void TakeDamage(int amount)
    {
        CurrentHealth = Mathf.Max(0, CurrentHealth - amount);
        Debug.Log($"Health: {CurrentHealth}/{MaxHealth}");
    }

    public void Heal(int amount)
    {
        CurrentHealth = Mathf.Min(MaxHealth, CurrentHealth + amount);
        Debug.Log($"Health: {CurrentHealth}/{MaxHealth}");
    }

    public bool IsAlive()
    {
        return CurrentHealth > 0;
    }
}
