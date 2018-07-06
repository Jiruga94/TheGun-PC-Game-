﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OppositeDir : MonoBehaviour {

    float speed=0.0f;
    private AudioManager audioManager;
    
    void Start()
    {
        speed = Random.Range(-1.5f, -3.0f);
        audioManager = AudioManager.instance;
        audioManager.PlaySound("FlyBy");
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer")
        {
            Destroy(gameObject);
        }
    }
}