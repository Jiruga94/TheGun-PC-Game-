using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequencesOfEliteDeath : MonoBehaviour {

    public Transform leftCorpses;
    public Transform rightCorpses;
    private EnemyStatistic enemy;
    public Transform pointTospawn;
    public bool enemyCorpses;
    public Transform explosionEffect;
    private int counter;
	void Start () {
        enemyCorpses = false;
        counter = 0;
	}
	
	// Update is called once per frame
	void Update () {
        Explosion();
        	}
    public void Explosion()
    {
        if (enemyCorpses==true)
        {
            counter += 1;
            Transform explo = Instantiate(explosionEffect, pointTospawn.transform.position, pointTospawn.transform.rotation);
            Destroy(explo.gameObject, 1.0f);
            Transform explode = Instantiate(rightCorpses, pointTospawn.transform.position, pointTospawn.transform.rotation);
            Transform secondExplode = Instantiate(leftCorpses, pointTospawn.transform.position, pointTospawn.transform.rotation);
            enemyCorpses= false;
            Destroy(explo.gameObject, 0.8f);
            if (counter>1)
            {
                Destroy(explode.gameObject, 0.3f);
                Destroy(secondExplode.gameObject, 0.3f);
            }

            return;
        }
    }
}
