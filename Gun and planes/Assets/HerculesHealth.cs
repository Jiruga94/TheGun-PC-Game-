using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HerculesHealth : MonoBehaviour {
    [SerializeField]
    private Transform explosion;
    [SerializeField]
    private Transform explosionPoint;
    [SerializeField]
    private Transform secondExpPoint;
    private int maxHealth;
    private int currentHealth;
    private int _damage;
    [SerializeField]
    private StatusIndicator statusIndicator;
    private Elite elite;
    [HideInInspector]
    public bool alive;
    private MoveHrc moveHrc;
    private Counter time;
    private ScoreManager scoreManager;
    private const int scoreCount = 200;
    private BarrelStats BarrelStats;
    private AudioManager audioManager;
    private GoldScript myGold;
    private const int goldSalary=50;
    private StatsScript sc;
    public int _Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    private void Start()
    {
        sc = FindObjectOfType<StatsScript>();
        audioManager = AudioManager.instance;
        BarrelStats = FindObjectOfType<BarrelStats>();
        alive = true;
        elite = FindObjectOfType<Elite>();
        maxHealth = Random.Range(7500, 10000);
        _Health = maxHealth;
        moveHrc = FindObjectOfType<MoveHrc>();
        time = FindObjectOfType<Counter>();
        scoreManager = FindObjectOfType<ScoreManager>();
        myGold = FindObjectOfType<GoldScript>();
    }
    public void Damage(int damage)
    {
        _Health -= damage;
        if (_Health<=0)
        {
            
            audioManager.StopSound("HerculesFlying");
            audioManager.PlaySound("HerculesFallin");
            myGold.GoldSalary(goldSalary);
            myGold.TotalGoldSalary(goldSalary);
            time.reset = true;
            alive = false;
            elite.isPresent = true;
            elite._random = 1;
            scoreManager.ScoreUpdate(scoreCount);
        }


    }
    private void Update()
    {
        if (statusIndicator!=null)
        {
            statusIndicator.SetHealth(currentHealth, maxHealth);
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            Damage(BarrelStats.damage);
        }
        if (collision.tag=="Ground"||collision.tag=="Destroyer"||collision.tag=="Barrel")
        {
            audioManager.StopSound("HerculesFallin");
            if (moveHrc.flip == false)
            {
                Transform explo = Instantiate(explosion, explosionPoint.transform.position, transform.rotation);
                audioManager.PlaySound("HerculesExplosion");
                Destroy(explo.gameObject, 1.0f);
                sc.myContent[sc.Hercules] += 1;
                Destroy(this.gameObject);
            }
            if (moveHrc.flip == true) {
                Transform explo = Instantiate(explosion, secondExpPoint.transform.position, transform.rotation);
                audioManager.PlaySound("HerculesExplosion");
                Destroy(explo.gameObject, 1.0f);
                sc.myContent[sc.Hercules] += 1;
                Destroy(this.gameObject);
            }
        }
        if (collision.tag == "FlipX" && _Health <= 0)
        {
            Transform explo = Instantiate(explosion, explosionPoint.transform.position, transform.rotation);
            Destroy(explo.gameObject, 1.0f);
          
            Destroy(this.gameObject);
        }
        if(collision.tag=="Flip_X"&& _Health <= 0)
        {
            Transform explo = Instantiate(explosion, secondExpPoint.transform.position, transform.rotation);
            Destroy(explo.gameObject, 1.0f);
          
            Destroy(this.gameObject);
        }
        if(collision.tag=="AllDestroyed"){
            Damage(maxHealth);
        }
    }
}
