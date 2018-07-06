using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmallPlaneHealth : MonoBehaviour {
    private bool hit;
    [SerializeField]
    private Transform sparks;
    [SerializeField]
    private Transform point;
    private int currentHealth = 0;
    private int maxHealth = 170;
    private Elite elite;
    [SerializeField]
    private StatusIndicator statusIndicator;
    private BarrelStats BarrelStats;
    private AudioManager audioManager;
    private GoldScript myGold;
    private const int goldsSalary = 10;
    private ScoreManager scoreManager;
    private StatsScript sc;
    private const int scorePoints = 25;
    void Start()
    {
        myGold = FindObjectOfType<GoldScript>();
        audioManager = AudioManager.instance;
        BarrelStats = FindObjectOfType<BarrelStats>();
        currentHealth = maxHealth;
        hit = false;
        elite = FindObjectOfType<Elite>();
        scoreManager = FindObjectOfType<ScoreManager>();
        sc = FindObjectOfType<StatsScript>();
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
            sc.myContent[sc.SmallPlanes] += 1;
            audioManager.PlaySound("SmallPlaneExplosion");
            Transform deathEffect = Instantiate(sparks, point.transform.position, point.transform.rotation);
            Destroy(deathEffect.gameObject, 0.5f);
            scoreManager.ScoreUpdate(scorePoints);
            myGold.GoldSalary(goldsSalary);
            myGold.TotalGoldSalary(goldsSalary);
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
