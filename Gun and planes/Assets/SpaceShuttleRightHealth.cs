using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShuttleRightHealth : MonoBehaviour {

    private bool hit;
    private int currentHealth = 0;
    private int maxHealth = 75;
    public bool imHere;
    [SerializeField]
    private Transform explosion;
    [SerializeField]
    private Transform point;
    private Elite elite;
    [SerializeField]
    private StatusIndicator statusIndicator;
    private BarrelStats BarrelStats;
    [HideInInspector]
    public float myPoint = 0.0f;
    private ApacheMove ac;
    private bool RocketHit;
    private bool MGFHit;
    AudioManager audiomananger;
    private GoldScript myGold;
    private const int goldSalary = -200;
    private StatsScript sc;
    private ScoreManager sm;
    private const int scorePoints = -1000;
    void Start()
    {
        sc = FindObjectOfType<StatsScript>();
        myGold = FindObjectOfType<GoldScript>();
        audiomananger = AudioManager.instance;
        ac = new ApacheMove();
        RocketHit = false;
        MGFHit = false;
        myPoint = transform.position.y;
        Debug.Log("point from health " + myPoint);
        BarrelStats = FindObjectOfType<BarrelStats>();
        currentHealth = maxHealth;
        hit = false;
        elite = FindObjectOfType<Elite>();
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
            sc.myContent[sc.SpaceShuttle] += 1;
            myGold.GoldSalary(goldSalary);
            myGold.TotalGoldSalary(goldSalary);
            audiomananger.StopSound("SpaceShuttleSlowDown");
            audiomananger.PlaySound("SmallPlaneExplosion");
            sm.ScoreUpdate(scorePoints);
            Transform deathEffect = Instantiate(explosion, point.transform.position, point.transform.rotation);
            Destroy(deathEffect.gameObject, 0.5f);
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
        if (RocketHit == true)
        {
            TakeDamage(BarrelStats.ApacheRocketDamage);
            RocketHit = false;
        }
        if (MGFHit == true)
        {
            TakeDamage(BarrelStats.ApacheMGDamage);
            MGFHit = false;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hit = true;
        }
        if (collision.tag == "ApacheRocket")
        {
            RocketHit = true;
        }
        if (collision.tag == "ApacheBullet")
        {
            MGFHit = true;
        }
        if (collision.tag == "Apache")
        {
            Transform deathEffect = Instantiate(explosion, point.transform.position, point.transform.rotation);
            Destroy(deathEffect.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
        if(collision.tag=="AllDestroyed")
        {
           TakeDamage(maxHealth);
        }
    }
}
