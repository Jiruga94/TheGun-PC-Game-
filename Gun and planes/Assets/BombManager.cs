using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombManager : MonoBehaviour {
    public Transform deathEff;
    public float damage = 0f;
    private ScoreManager scoreM;
    private AudioManager audioManager;
    public float scoreCount = 0f;
    public string soundName;
    [HideInInspector]
    public bool HitByBomb;
    private GoldScript myGold;
    private const int goldSalary=5;
    private StatsScript sc;
    private const int scorePoints = 5;
	void Start () {
        scoreM = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
        audioManager.PlaySound("BombFallin");
        myGold = FindObjectOfType<GoldScript>();
        sc = FindObjectOfType<StatsScript>();
    }
	void Update () {
        HitByBomb = false;        
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrel")
        {
            HitByBomb =true;
            audioManager.StopSound("BombFallin");
         
                audioManager.PlaySound(soundName);
            
            Death();
           
          
        }
        if (collision.tag=="Bullet")
        {
            sc.amountOfRocket += 1;
            myGold.GoldSalary(goldSalary);
            myGold.TotalGoldSalary(goldSalary);
            audioManager.StopSound("BombFallin");
            Death();
           
                audioManager.PlaySound(soundName);
            
            scoreM.ScoreUpdate(scorePoints);
        }
        if (collision.tag=="Ground")
        {
            audioManager.StopSound("BombFallin");
            Death();
           
                audioManager.PlaySound(soundName);
            
        }
        if (collision.tag == "Destroyer")
        {
            Death();
            audioManager.StopSound("BombFallin");
        }
        if(collision.tag=="AllDestroyed"){
            Death();
        }
    }
    void Death()
    {
       
        Transform deathEffect = Instantiate(deathEff, transform.position, transform.rotation);
        Destroy(deathEffect.gameObject,0.7f);
        Destroy(gameObject);
        

    }
    
}
