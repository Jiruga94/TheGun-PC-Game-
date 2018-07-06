using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ApacheRightRespawn : MonoBehaviour{
    

    private delegate  void WhatNow();
    [System.Serializable]
    public class ApacheState
    {
        public string Name;
        public Transform enemy;
    }
   
    private float TimeBetweenWaves = 40f;
    public ApacheState[] apache;
    [SerializeField]
    private Transform[] spawnPoints;
    private float currentTime = 0.0f;
    private ApacheState ap=new ApacheState();
    private GameObject[] enemyArray= new GameObject[99];
    private bool respawn;
    private int myCounterOfArray=1;
    private GameObject en;
    private WaveSpawner waveSpawner;
    private GameObject gameO;
    private bool reborn;

    
    void Start()
    {
  
        waveSpawner = FindObjectOfType<WaveSpawner>();
      
        currentTime = TimeBetweenWaves;
        for (int i = 0; i < enemyArray.Length; i++)
        {
            enemyArray[i] = null;
            
        }
        for (int i = 0; i <myCounterOfArray; i++)
        {
            enemyArray[i] = en;
           
        }
        foreach (var item in enemyArray)
        {
            //Debug.Log("zawartosc tablicy " +item);
        }
        myCounterOfArray++;
        respawn = false;
        Debug.Log("czas do rspa" + currentTime);
    }
    private void Update()
    {
        if (gameO!=null)
        {
            Debug.Log("Jest na mapie");
            return;
        }
        else
        {
           // Debug.Log("He isn't here");
        }
       
         if (currentTime>0)
         {
             currentTime -= Time.deltaTime;
           
             if (currentTime<=0)
             {
                 Debug.Log("powienien pojawic sie przeciwnik");

                 TimeToRespawn(apache[0]);
                 AmountOfApache();
                 currentTime = TimeBetweenWaves;
                 
             }
         }

    }

    void TimeToRespawn(ApacheState _apache)
    {
        reborn = true;
        StartApacheRespawn(_apache.enemy);
        
    }
    private void StartApacheRespawn(Transform _enemy)
    {
        if (currentTime <= 0)
        {
            Transform Points = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(_enemy, Points.transform.position, Points.transform.rotation);
        }
    }
    public GameObject[] AmountOfApache()
    {
        if (respawn == true)
        {
            for (int i = myCounterOfArray - 1; i < myCounterOfArray; i++)
            {
                enemyArray[myCounterOfArray - 1] =en;

            }
            foreach (var item in enemyArray)
            {
                Debug.Log("amount apaches " + item.name);
            }
            return enemyArray;
        }
        else { return enemyArray; }
    }

}
