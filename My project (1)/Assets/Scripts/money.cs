using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class money : MonoBehaviour
{
    public TextMeshProUGUI amountonScreen;
    public float startAmount;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        amountonScreen.SetText("$" + startAmount.ToString());
    }

    public void addMoney(float amount)
    {
        startAmount += amount;
    }
}
