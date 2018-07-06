using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UfoHealth : MonoBehaviour {
    private bool hit;
    [SerializeField]
    private Transform sparks;
    [SerializeField]
    private Transform point;
    private int currentHealth = 0;
    private int maxHealth = 150;
    private AudioManager audiomanager;
    private BarrelStats BarrelStats;
    [SerializeField]
    private StatusIndicator statusIndicator;
    private GoldScript myGold;
    private const int goldSalary=15;
    private const int scorePoints = 30;
    private StatsScript sc;
    private ScoreManager sm;
    void Start()
    {
        sc = FindObjectOfType<StatsScript>();
        audiomanager = AudioManager.instance;
        currentHealth = maxHealth;
        hit = false;
        BarrelStats = FindObjectOfType<BarrelStats>();
        myGold = FindObjectOfType<GoldScript>();
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
        if (_Health == 0)
        {
            sc.myContent[sc.SmallUfo] += 1;
            audiomanager.StopSound("UfoLaser");
            audiomanager.PlaySound("UfoDeath");
            myGold.GoldSalary(goldSalary);
            myGold.TotalGoldSalary(goldSalary);
            sm.ScoreUpdate(scorePoints);
            Transform deathEffect = Instantiate(sparks, point.transform.position, point.transform.rotation);
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
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Bullet")
        {
            hit = true;
        }
        if(collision.tag=="AllDestroyed")
        {
           TakeDamage(maxHealth);
        }
    }
}
