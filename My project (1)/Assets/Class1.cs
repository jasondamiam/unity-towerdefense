using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using UnityEngine.SocialPlatforms.Impl;

internal class Authientication
{
    private static Authientication _instance;
    public int score = 0;
    private Authientication()
    {
        score = 0;
    }

    public static Authientication Getinstance()
    {
        if (_instance == null)
        {
            _instance = new Authientication();
        }
        return _instance;
    }
    public void AddScore(int someScore)
    {
        score += someScore;
    }
    


}