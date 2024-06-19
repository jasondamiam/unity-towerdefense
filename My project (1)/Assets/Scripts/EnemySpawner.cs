using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{

    [SerializeField] private float countdown;
    [SerializeField] private GameObject Spawnpoint;
    public wave[] waves;
    private int currentwaveindex = 0;
    private void Start()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesleft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {
        countdown -= Time.deltaTime;


        if (countdown <= 0 && currentwaveindex < waves.Length)
        {
            countdown = waves[currentwaveindex].TimeToNextWave;
            StartCoroutine(SpawnWave()); 
        }
        
        
    }
    private IEnumerator SpawnWave()
    {
        Debug.Log("Spawning enemy");
        for (int i = 0; i < waves[currentwaveindex].enemies.Length; i++)
        {
            
            Enemy enemy = Instantiate (waves[currentwaveindex].enemies[i],Spawnpoint.transform).GetComponent<Enemy>();
            enemy.transform.SetParent(Spawnpoint.transform);
            yield return new WaitForSeconds(waves[currentwaveindex].TimeToNextEnemy);
        }
        if(currentwaveindex + 1 < waves.Length)
        {
            currentwaveindex++;
            countdown = waves[currentwaveindex].TimeToNextWave;
        }
    }

    [System.Serializable]
    public class wave
    {
        public GameObject[] enemies;
        public float TimeToNextEnemy;
        public float TimeToNextWave;
        [HideInInspector] public int enemiesleft;
    }
}
