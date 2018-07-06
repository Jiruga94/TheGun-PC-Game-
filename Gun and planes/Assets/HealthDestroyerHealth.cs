﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthDestroyerHealth : MonoBehaviour {

    private bool hit;
    private int currentHealth = 0;
    private int maxHealth = 100;
    private AudioManager audioManager;
    [SerializeField]
    private Transform explosion;
    private BarrelStats BarrelStats;
    [SerializeField]
    private StatusIndicator statusIndicator;
    [HideInInspector]
    public bool goingDown;
    private StatsScript sc;
    private const int scorePoints = 20;
    private ScoreManager sm;
    void Start()
    {
        sc = FindObjectOfType<StatsScript>();
        goingDown = false;
        currentHealth = maxHealth;
        hit = false;
        audioManager = AudioManager.instance;
        BarrelStats = FindObjectOfType<BarrelStats>();
        sm = FindObjectOfType<ScoreManager>();
    }

    public int _Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    void TakeDamage(int damage)
    {
        _Health -= damage;
        if (_Health <= 0)
        {
            sc.myContent[sc.Apache] += 1;
           
            audioManager.StopSound("HelicopterFly");
            audioManager.PlaySound("HelicopterDestroyed");
            goingDown = true;
            sm.ScoreUpdate(scorePoints);
            Transform Explosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(Explosion.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
    }
    void Update()
    {

        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(currentHealth, maxHealth);
        }
        if (hit == true)
        {
            TakeDamage(BarrelStats.damage);
            hit = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hit = true;
        }
        if (collision.tag=="SpaceShuttle")
        {
            Transform Explosion = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(Explosion.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
        if(collision.tag=="AllDestroyed"){
            _Health-=maxHealth;
        }
       
    }
}