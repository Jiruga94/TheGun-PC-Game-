﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour {
    public Transform deathEffect;

	// Use this for initialization
	void Awake () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag=="Bullet")
        {
           
          //  Transform destroy = Instantiate(deathEffect, transform.position, transform.rotation);
            Destroy(gameObject);
            
            
            
        }
    }
}