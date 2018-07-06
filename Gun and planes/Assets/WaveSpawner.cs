using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveSpawner : MonoBehaviour {
    public enum SpawnState {SPAWNING,WAITING,COUNTING }

    [System.Serializable]
public class Wave
    {
        
        public string Name;
        public Transform enemy;
        public int count;
        public float rate;
    }
    public Wave[] waves;
    private int nextWave = 0;
    public Transform[] spawnPoints;
    
    public float TimeBetweenWaves = 0f;
    private float waveCountdown;
    private float searchCountDown = 1f;
    private SpawnState state = SpawnState.COUNTING;
    

     void Start()
    {
       
        if (spawnPoints.Length == 0)
        {
            Debug.LogError("No spawn points");
        }
        waveCountdown = TimeBetweenWaves;
    }
    void Update()
    {

        if (state == SpawnState.WAITING)
        {
           
            if (!EnemyIsAlive())
            {
                WaveCompleted();
            }
            else
            {
                return;
            }
        }

        if (waveCountdown<=0)
        {
           
            if (state!=SpawnState.SPAWNING)
            {
                
                StartCoroutine(SpawnWave(waves[nextWave]));
               
            }
        }
        else
        {
           
            waveCountdown -= Time.deltaTime;
           // Debug.Log("Spawning next waves" + waveCountdown);
        }
    }
    void WaveCompleted()
    {
        Debug.Log("Wave completed!!!");
        state = SpawnState.COUNTING;
        waveCountdown = TimeBetweenWaves;
       
        if (nextWave+1>waves.Length-1)
        {
            nextWave = 0;
            Debug.Log("Completed all waves looping....");
            
        }
        else
        {
            nextWave++;
        }
        
    }
    bool EnemyIsAlive()
    {
        searchCountDown -= Time.deltaTime;
        if (searchCountDown <= 0f)
        {
            searchCountDown = 1f;
            if (GameObject.FindGameObjectWithTag("Enemy") == null)
            {
                return false;
            }
        }
        return true;
    }
    IEnumerator SpawnWave(Wave _wave)
    {
        Debug.Log("Spawning Wave:  " + _wave.Name);
        state = SpawnState.SPAWNING;
       
        for (int i = 0; i < _wave.count; i++)
        {
            SpawnEnemy(_wave.enemy);
           
            yield return new WaitForSeconds(1f / _wave.rate);
        }


        state = SpawnState.WAITING;
        yield break;
    }
    void SpawnEnemy(Transform _enemy)
    {
        Debug.Log("Spawning enemy:" + _enemy.name);
       
      
        Transform _sp = spawnPoints[Random.Range(0, spawnPoints.Length)];
        Instantiate(_enemy, _sp.position, _sp.rotation);
   
        
    }
}
