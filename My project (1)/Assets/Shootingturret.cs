using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingturret : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float HowClose;
    public Transform Head;
    // Start is called before the first frame update
    void Start()
    {
        _Player = GameObject.FindGameObjectWithTag("Player").transform;
    }

        // Update is called once per frame
        void Update()
        {
            dist = Vector3.Distance(_Player.position, transform.position);
            if (dist <= HowClose)
            {
                Head.LookAt(_Player);
            }
        }
    }
