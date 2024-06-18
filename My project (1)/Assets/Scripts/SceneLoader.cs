using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class SceneLoader : MonoBehaviour
{
    public void FirstLevel()
    {
        SceneManager.LoadScene(0);
    }

    public void SecondLevel()
    {
        SceneManager.LoadScene(1);
    }
}
