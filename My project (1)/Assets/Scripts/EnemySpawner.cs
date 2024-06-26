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
    public GameObject PausePanel, TowerSelector, MoneyScreen, HealthBar, GameOver;
    private int currentwaveindex = 0;
    private int activeEnemies = 0;
    private bool allWavesSpawned = false;
    private void Start()
    {
        for (int i = 0; i < waves.Length; i++)
        {
            waves[i].enemiesleft = waves[i].enemies.Length;
        }
    }
    private void Update()
    {

        if (!allWavesSpawned)
        {
            countdown -= Time.deltaTime;


            if (countdown <= 0 && currentwaveindex < waves.Length)
            {
                countdown = waves[currentwaveindex].TimeToNextWave;
                StartCoroutine(SpawnWave());
            }

        }
        else if(activeEnemies == 0)
        {
            Win();
        }
    }
    private IEnumerator SpawnWave()
    {
        Debug.Log("Spawning enemy");
        for (int i = 0; i < waves[currentwaveindex].enemies.Length; i++)
        {

            Enemy enemy = Instantiate(waves[currentwaveindex].enemies[i], Spawnpoint.transform).GetComponent<Enemy>();
            enemy.transform.SetParent(Spawnpoint.transform);
            yield return new WaitForSeconds(waves[currentwaveindex].TimeToNextEnemy);

            activeEnemies++;
        }
        if (currentwaveindex + 1 < waves.Length)
        {
            currentwaveindex++;
            countdown = waves[currentwaveindex].TimeToNextWave;
        }
        else
        {
            allWavesSpawned = true;
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
    public void enemyDestroyed()
    {
        activeEnemies--;

        if (currentwaveindex >= waves.Length && activeEnemies == 0)
        {
            Win();
        }
    }
    private void Win()
    {
        PausePanel.SetActive(false);
        TowerSelector.SetActive(false);
        MoneyScreen.SetActive(false);
        HealthBar.SetActive(false);
        GameOver.SetActive(true);
        Time.timeScale = 0;
    }
}
