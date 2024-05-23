using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shootingturret : MonoBehaviour
{
    Transform _Player;
    float dist;
    public float HowClose;
    public Transform Head;
    public GameObject _Projectile;
    public float projectilespeed;
    public float FireRate,NextFire;
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
            if(Time.time >= NextFire)
            {
                NextFire = Time.time + 1f / FireRate;
                Shoot();

            }
            
            }
        }
          void Shoot()
    {
        GameObject clone = Instantiate(_Projectile, Head.position,Head.rotation);
        clone.GetComponent<Rigidbody>().AddForce(Head.forward * projectilespeed);
        Destroy(clone, 2);
    }

    }
