using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStatistic : MonoBehaviour {
   
    public class EnemySt
    {
       
        public int _currentHealth;
        public int _maxHealth;
        public int _damage = 50;
        public bool _hit;

        public int _Health
        {
            get { return _currentHealth; }
            set { _currentHealth = Mathf.Clamp(value, 0, _maxHealth); }
        }
    }
    public EnemySt stats = new EnemySt();
    [Header("Optional: ")]
    [SerializeField]
    private StatusIndicator statusIndicator;
    private Elite elite;
    private Counter timer;
    public bool dead;
    private float one = 1.0f;
    private ScoreManager scoreManager;
    public Res r;
    private const int scoreCount = 200;
    private BarrelFire ls;
    private LastBossController eliteControl;
    private BarrelStats BarrelStats;
    private SequencesOfEliteDeath corpses;
    private AudioManager audioManager;
    public bool destroyedElite;
    private Sample sample;
    private GoldScript myGold;
    private const int goldSalary=50;
    private StatsScript sc;

    void Start ()
    {
        myGold = FindObjectOfType<GoldScript>();
        sample = FindObjectOfType<Sample>();
        destroyedElite = false;
        audioManager = AudioManager.instance;
        corpses = FindObjectOfType<SequencesOfEliteDeath>();
        ls = FindObjectOfType<BarrelFire>();
        scoreManager = FindObjectOfType<ScoreManager>();
        elite = FindObjectOfType<Elite>();
        timer = FindObjectOfType<Counter>();
        stats._maxHealth = Random.Range(2500, 3000);
        stats._Health = stats._maxHealth;
        eliteControl = FindObjectOfType<LastBossController>();
        BarrelStats = FindObjectOfType<BarrelStats>();
        audioManager.PlaySound("UfoPresent");
        sc = FindObjectOfType<StatsScript>();
    }
   
    public void DamageEnemy(int damage)
    {
        if (eliteControl.shield == false)
        {
            stats._Health -= damage;
            if (stats._Health <= 0)
            {
                sc.myContent[sc.Elite] += 1;
                Debug.Log("zabite eliyty " + sc.myContent[sc.Elite]);
                sample.bright = true;
                myGold.GoldSalary(goldSalary);
                myGold.TotalGoldSalary(goldSalary);
                destroyedElite = true;
                elite.darkness = false;
                audioManager.StopSound("PresentTime");
                ls.LifeDrainDamage = false;
                elite.isPresent = true;
                r = Res.timeCount;
                timer.reset = true;
                elite._random = Random.Range(1, 3);
                Destroy(this.gameObject);
                scoreManager.ScoreUpdate(scoreCount);
                dead = true;
                audioManager.StopSound("UfoPresent");
                audioManager.PlaySound("Dying");
                corpses.enemyCorpses = true;
                elite._random = 2;
                Debug.Log(r + " state");
                Debug.Log("Elite has banished!!!");

            }
        }
       
    }
   
    void Update () {
        if (stats._hit==true)
        {
       DamageEnemy(BarrelStats.damage);
            stats._hit = false;
        }
        if (ls.LifeDrainDamage==true)
        {
            stats._Health += 9;
            if (eliteControl.rage<=0)
            {
                stats._Health += 11;
            }
        }      
        if (statusIndicator != null)
        {
            statusIndicator.SetHealth(stats._currentHealth, stats._maxHealth);
        }
        if (stats._Health == stats._maxHealth)
        {
            r = Res.timebtwFight;
        }
       
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {

            stats._hit = true;
            
        }
        if(collision.tag=="AllDestroyed"){
            eliteControl.shield=false;
           DamageEnemy(stats._maxHealth);
        }
    }
}
