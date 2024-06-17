using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using System.Collections;

public class EnemySpawner : MonoBehaviour
{
    private void Start()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesleft = waves[i].enemies.Length;
        }
    }
    [SerializeField]private float countdown;
    [SerializeField] private GameObject Spawnpoint;
    public wave[] waves;
    private int currentwaveindex = 0;
    private void Update()
    {
        countdown -= Time.deltaTime;


        if (countdown <= 0)
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
            //GameObject.tag = "Player";
            Enemy enemy = Instantiate (waves[currentwaveindex].enemies[i],Spawnpoint.transform).GetComponent<Enemy>();
            enemy.transform.SetParent(Spawnpoint.transform);
            yield return new WaitForSeconds(waves[currentwaveindex].TimeToNextEnemy);
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
