using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public List<Vector3> vindpunten = new List<Vector3>();
    public float snelheid = 2f; // Lagere snelheid voor langzamere beweging
    public int naartoe = 0;

    void Start()
    {
        if (vindpunten.Count > 0)
        {
            transform.position = vindpunten[0];
        }
        else
        {
            Debug.LogWarning("De lijst met vindpunten is leeg!");
        }
    }

    void Update()
    {
        if (vindpunten.Count == 0) return;

        if (naartoe < 0 || naartoe >= vindpunten.Count)
        {
            Debug.LogError("Index 'naartoe' is buiten de grenzen van de lijst 'vindpunten'.");
            return;
        }

        // Beweeg de vijand naar het huidige doelpunt
        Vector3 huidigePositie = transform.position;
        Vector3 doelPositie = vindpunten[naartoe];
        float stap = snelheid * Time.deltaTime; // Berekent de stapgrootte op basis van snelheid en tijdsdelta

        transform.position = Vector3.MoveTowards(huidigePositie, doelPositie, stap);

        // Controleer of de vijand het huidige doelpunt heeft bereikt
        if (Vector3.Distance(huidigePositie, doelPositie) < 0.1f)
        {
            naartoe++;
            if (naartoe >= vindpunten.Count)
            {
                naartoe = vindpunten.Count - 1; // Zet naar het laatste punt en stop
                enabled = false; // Schakel de update uit om de vijand te stoppen
            }
        }
    }

    private void OnDrawGizmos()
    {
        if (vindpunten == null) return;

        Gizmos.color = Color.red;
        for (int i = 0; i < vindpunten.Count - 1; i++)
        {
            Gizmos.DrawLine(vindpunten[i], vindpunten[i + 1]);
        }

        if (vindpunten.Count > 1)
        {
            Gizmos.DrawLine(vindpunten[vindpunten.Count - 1], vindpunten[0]); // Tekent een lijn terug naar het eerste punt
        }
    }
}
