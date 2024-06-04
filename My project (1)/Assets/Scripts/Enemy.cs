using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    // Start is called before the first frame update
    public List<Vector3> vindpunten = new List<Vector3>();
    public float snelheid = 10;
    public int naartoe;
    public float health;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, vindpunten[naartoe], snelheid * Time.deltaTime);
        //transform.LookAt()
        if(transform.position == vindpunten[naartoe])
        {
            naartoe++;
            if(naartoe == vindpunten.Count)
            {
                Destroy(gameObject);
            }

        }
    }
    
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        for(int i = 0; i < vindpunten.Count - 1; i++)
        {
            Gizmos.DrawLine(vindpunten[i], vindpunten[i + 1]);
        }
    }
    public void TakeDamage(float damage)
    {
        Debug.Log("WHAAAAAAAAAAAAAAA");
        health -= damage;
        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
