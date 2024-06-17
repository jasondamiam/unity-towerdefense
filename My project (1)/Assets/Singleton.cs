using System.Collections;
using System.Collections.Generic;
using System.Net.Security;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;

public class Singleton : MonoBehaviour
{
    private void Update()
    {
        Authientication scores = Authientication.Getinstance();
        scores.AddScore(2);
    }
}