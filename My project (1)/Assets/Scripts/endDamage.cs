using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class endDamage : MonoBehaviour
{
    public float damage;

    private void OnCollisionEnter(Collision collision)
    {
        GetComponent<gameStats>().MinusHealth(damage);
    }
}
