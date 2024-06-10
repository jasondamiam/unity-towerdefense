using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using UnityEngine;
using UnityEngine.UI;

public class EndTower : MonoBehaviour
{
    private HealthBar healthBarInstance;  // Verander de naam van het veld om conflicten te voorkomen
    public Slider healthBarSlider;

    private void Start()
    {
        healthBarInstance = HealthBar.GetInstance();
        if (healthBarSlider != null)
        {
            healthBarSlider.maxValue = healthBarInstance.MaxHealth;
            healthBarSlider.value = healthBarInstance.CurrentHealth;
        }
    }

    public void TakeDamage(int amount)
    {
        healthBarInstance.TakeDamage(amount);
        if (healthBarSlider != null)
        {
            healthBarSlider.value = healthBarInstance.CurrentHealth;
        }
        if (!healthBarInstance.IsAlive())
        {
            Debug.Log("EndTower is destroyed!");
        }
    }

    public void Heal(int amount)
    {
        healthBarInstance.Heal(amount);
        if (healthBarSlider != null)
        {
            healthBarSlider.value = healthBarInstance.CurrentHealth;
        }
    }

    public HealthBar HealthBar
    {
        get { return healthBarInstance; }
    }
}
