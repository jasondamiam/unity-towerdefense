using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{

    public GameObject PausePanel, TowerSelector, MoneyScreen;
    private bool PauseMenuOn = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (PauseMenuOn)
            {
                Continue();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        PausePanel.SetActive(true);
        TowerSelector.SetActive(false);
        MoneyScreen.SetActive(false);
        Time.timeScale = 0;
        PauseMenuOn = true;
    }

    public void Continue()
    {
        PausePanel.SetActive(false);
        TowerSelector.SetActive(true);
        MoneyScreen.SetActive(true);
        Time.timeScale = 1;
        PauseMenuOn = false;
    }
}
