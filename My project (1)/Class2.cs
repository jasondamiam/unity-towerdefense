using System;
using UnityEngine.UI;
using UnityEngine;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


public class program : MonoBehaviour
{
    void Start()
    {
        EndTower tower1 = new GameObject("Tower1").AddComponent<EndTower>();
        tower1.healthBarSlider = FindObjectOfType<Slider>();  // Stel de slider in voor demonstratiedoeleinden
        EndTower tower2 = new GameObject("Tower2").AddComponent<EndTower>();
        tower2.healthBarSlider = FindObjectOfType<Slider>();  // Stel de slider in voor demonstratiedoeleinden

        tower1.TakeDamage(30);
        tower2.TakeDamage(50);
        tower1.Heal(20);

        Debug.Log($"Health after actions: {tower1.HealthBar.CurrentHealth}/{tower1.HealthBar.MaxHealth}");
    }
}
