using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheRespawnRightPlace : MonoBehaviour {

    enum ApacheRespawn { respawn, wait }
    [SerializeField]
    private Transform enemy;
    [SerializeField]
    private Transform[] spawnPoints;
    private int timebtwnextenemy = 0;
    private int amount = 0;
    private bool stillRes;
    private float TimeToChargeNewApache = 0;
    ApacheRespawn arsp;


    void Start()
    {
        TimeToChargeNewApache = 15;
        arsp = ApacheRespawn.respawn;
        stillRes = true;
        if (GameObject.Find("Apache"))
        {
            Debug.Log("Apache exist!!!");
        }
    }


    void Update()
    {

      StartCoroutine(CountControll());

    }
    IEnumerator CountControll()
    {
        yield return new WaitForSeconds(15);
        if (arsp == ApacheRespawn.respawn && stillRes == true)
        {
            amount = 1;

            Transform takePoint = spawnPoints[Random.Range(0, spawnPoints.Length)];

            Transform MyApache = Instantiate(enemy, takePoint.transform.position, takePoint.transform.rotation);
            stillRes = false;
            arsp = ApacheRespawn.wait;


        }
        if (arsp == ApacheRespawn.wait && stillRes == false)
        {
            TimeToChargeNewApache -= Time.deltaTime;

            if (TimeToChargeNewApache < 0)
            {
                arsp = ApacheRespawn.respawn;
                stillRes = true;
                TimeToChargeNewApache = Random.Range(30, 50);
                Debug.Log("time to charge apache " + TimeToChargeNewApache);
            }
        }

    }


}


