using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHelalth : MonoBehaviour {
    private AudioManager audioManager;
    public float startingHealth = 0;
    private float currenthealth;
    public Transform hitEffect;
    public Transform deathEffect;
    public float damageHurt=0;
    bool isDead;
    
    private ScoreManager scoreM;
    public string soundName;
    private GameObject gameob;
    private float counter = 0f;
    private bool startCount;
    void Awake () {
        

        currenthealth = startingHealth;
	}
     void Start()
    {
        audioManager = FindObjectOfType<AudioManager>();
        audioManager = AudioManager.instance;
        scoreM = FindObjectOfType<ScoreManager>();
       
    }
   
	void Update () {
        if (startCount==true)
        {
           // counter += Mathf.Round(Time.time)/1000;
            Debug.Log(counter + " counter");
        }
        
       
    }
    public void TakeDamage(float amount)
    {
        if (isDead)
        {
            return;
        }
        currenthealth -= amount;
        Debug.Log("Current Health of enemy equal...:" + currenthealth);
       
        if (currenthealth<=0)
        {
            Death();
        }
    }
    void Death()
    {
        isDead = true;
        Transform explosion = Instantiate(deathEffect, transform.position, transform.rotation);
        if (currenthealth<0)
        {
            currenthealth = 0;
        }
        //scoreM.ScoreUpdate(CountPoins);
        Destroy(gameObject);
        DestroyGameObject(explosion);

        if (audioManager.wlacz == false)
        {
            audioManager.PlaySound(null);
        }
        if (audioManager.wlacz == true)

        {
            audioManager.PlaySound(soundName);
        }


        Debug.Log("is dead!");
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        
        if (collision.tag=="Unleashed")
        {
            Debug.Log("TOUCHED!!!!!");
            gameob.SetActive(false);
            startCount = false;
           
           
        }
        if (collision.tag=="ApacheRocket")
        {
            EnemyHelalth enemyHealth = GetComponent<EnemyHelalth>();
            enemyHealth.TakeDamage(50);
        }
        if (collision.tag == "ApacheBullet")
        {
            EnemyHelalth enemyHealth = GetComponent<EnemyHelalth>();
            enemyHealth.TakeDamage(1);
        }
        if (collision.tag == "Bullet")
        {
            
            EnemyHelalth enemyHealth = GetComponent<EnemyHelalth>();
            if (enemyHealth!=null)
            {
                Transform hit = Instantiate(hitEffect, transform.position, transform.rotation);
                enemyHealth.TakeDamage(damageHurt);
                
                DestroyGameObject(hit);
                
            }
            if (collision.tag == "Ground")
            {
                Death();
            }
        }
    }
   
    void DestroyGameObject(Transform gObject)
    {
        Destroy(gObject.gameObject, 0.7f);
    }
}
