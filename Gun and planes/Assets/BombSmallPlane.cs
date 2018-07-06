using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSmallPlane : MonoBehaviour {

    public Transform deathEff;
    public float damage = 0f;
    private ScoreManager scoreM;
    private AudioManager audioManager;
    public float scoreCount = 0f;
    private GoldScript gs;
    private const int goldSalary = 1;
    [HideInInspector]
    public bool HitByBomb;
    private const int scorePoints = 1;

    void Start()
    {
        scoreM = FindObjectOfType<ScoreManager>();
        audioManager = FindObjectOfType<AudioManager>();
        gs = FindObjectOfType<GoldScript>();
    }

    // Update is called once per frame
    void Update()
    {
        HitByBomb = false;

    }
    void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.tag == "Barrel")
        {
            HitByBomb = true;
           
            if (audioManager.wlacz == false)
            {
                audioManager.PlaySound(null);
            }
            if (audioManager.wlacz == true)

            {
                audioManager.PlaySound("BombExplosion");
            }
            Death();


        }
        if (collision.tag == "Bullet")
        {
            gs.GoldSalary(goldSalary);
            gs.TotalGoldSalary(goldSalary);  
            Death();
            if (audioManager.wlacz == false)
            {
                audioManager.PlaySound(null);
            }
            if (audioManager.wlacz == true)

            {
                audioManager.PlaySound("BombExplosion");
            }
            scoreM.ScoreUpdate(scorePoints);
        }
        if (collision.tag == "Ground")
        {
          
            Death();
            if (audioManager.wlacz == false)
            {
                audioManager.PlaySound(null);
            }
            if (audioManager.wlacz == true)

            {
                audioManager.PlaySound("BombExplosion");
            }
        }
        if (collision.tag == "Destroyer")
        {
            Death();
           

        }
        if(collision.tag=="AllDestroyed"){
            Death();
        }
    }
    void Death()
    {
        Transform deathEffect = Instantiate(deathEff, transform.position, transform.rotation);
        Destroy(deathEffect.gameObject, 0.7f);
        Destroy(gameObject);


    }

}