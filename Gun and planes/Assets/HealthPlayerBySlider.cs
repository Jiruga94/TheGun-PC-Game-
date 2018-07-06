using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthPlayerBySlider : MonoBehaviour {

    [SerializeField]
    public Slider healthBar;
    [HideInInspector]
    public int maxhealtValue = 500;
    [HideInInspector]
    public int minHealthValue=400;
    [HideInInspector]
    public int currentHealth;
    private int health;

    private int herculesBulletDamage=30;

    private float setOnFireDamage=25;
    private PlayerHealth playerHealth;
    private Elite elite;
    private BombManager bombManager;
    private BulletHrc bulletHrc;
    private HealthPackage healthPackage;
    private BarrelFire barrel;
    private BarrelStats barrelStats;
    private int damageFromDrainLife = 4;
    private int damageFromUfoFire = 20;
    public Text healthValue;
    private LastBossController lastBoss;
    private float t=3.0f;

    private int herculesBombDamage=35;

    private int FrostArrowDamage=80;
    private DoombringerController doombringer;
    private UnknownTimer unknownTimer;
    [HideInInspector]public bool restoreHp=true;
    private int one = 0;
	void Start () {
        
       doombringer=FindObjectOfType<DoombringerController>();
      unknownTimer=FindObjectOfType<UnknownTimer>();
        lastBoss = FindObjectOfType<LastBossController>();
        barrelStats = FindObjectOfType<BarrelStats>();
        elite = FindObjectOfType<Elite>();
        healthBar = GetComponent<Slider>();
        barrel = FindObjectOfType<BarrelFire>();
        health = Random.Range(250, 300);
        currentHealth = health;
        Debug.Log("Value of your health: " + health);
        healthBar.maxValue = health;
        healthBar.minValue = 0;
        healthBar.value = health;
        playerHealth = FindObjectOfType<PlayerHealth>();
        bombManager = FindObjectOfType<BombManager>();
        bulletHrc = FindObjectOfType<BulletHrc>();
        healthPackage = FindObjectOfType<HealthPackage>();
        healthValue.text = "Health: " + healthBar.maxValue;
        lastBoss = new LastBossController();
        restoreHp=false;
    
    }
	
	
	void Update () {
        healthValue.text = Mathf.Round(healthBar.value)+"/"+healthBar.maxValue;
        if (healthBar.value==0)
        {                                                    
            playerHealth.makeDead();
        }
       /* if (barrel.LifeDrainDamage==true)
        {
          DrainLife();
        }*/
        if (barrel.UfoDamage==true)
        {
            UfoLaser();
        }
       
        if (barrel.RocketHit==true)
        {
            RocketDamage();
        }
        if (barrel.BombHit==true)
        {
            BombDamage();
        }
        if (barrel.ApacheMachineGunHit==true)
        {
            ApacheMachineGun();
        }
        if (barrel.ApacheRocket==true)
        {
            ApacheRocket();
        }
        if (barrel.LifeDrainDamage==true)
        {
            DrainLife();
        }
        if (barrel.HerculesBulletHit==true)
        {
            HerculesBullet();
        }
        if (barrel.herculesBombHit==true)
        {
            HrcBombDamage();
        }
        if (barrel.incrementHealth==true)
        {
            HealthPackage();
            barrel.incrementHealth = false;
        }
        if(barrel.setOnFire==true){
            SetOnFire();
            t-=Time.deltaTime;
            
            if(t<=0){
                barrel.setOnFire=false;
                t=3;

            }
        }
        if(unknownTimer.unknowCount<=0&& restoreHp==true){
            if(one==0){
            
            healthBar.value+=health;
                one=1;
               restoreHp=false;
            }
        }
     
        if(barrel.drainFrost==true){
                DrainFrost();
            }
        if(barrel.frostArrow==true)
        {
            FrostArrow();
        }
    }
  


    public void DrainFrost()
    {     
     healthBar.value-=Time.deltaTime/2;
    }
    public void DrainLife()
    {

       
        if (lastBoss.rage<=0)
        {
            healthBar.value -= Time.deltaTime * 2.6f*damageFromDrainLife;
        }
        else { healthBar.value -= Time.deltaTime * 2*damageFromDrainLife; }

    }
    public void UfoLaser()
    {
        healthBar.value -= Time.deltaTime * damageFromUfoFire;
    }
    public void RocketDamage()
    {
        healthBar.value -= 15/barrelStats.Armor;
        barrel.RocketHit = false;
    }
    private void BombDamage()
    {
        healthBar.value -= 5/barrelStats.Armor;
        barrel.BombHit = false;
    }
    private void ApacheMachineGun()
    {
        healthBar.value -= 1/barrelStats.Armor;
        barrel.ApacheMachineGunHit = false;
    }
    private void ApacheRocket()
    {
        healthBar.value -= 10/barrelStats.Armor;
        barrel.ApacheRocket = false;
    }
    private void HerculesBullet()
    {
        healthBar.value -= herculesBulletDamage/barrelStats.Armor;
        barrel.HerculesBulletHit = false;
    }
    private void HrcBombDamage()
    {
        healthBar.value -= herculesBombDamage/barrelStats.Armor;
        barrel.herculesBombHit = false;
    }
    private void HealthPackage()
    {
        healthBar.value += 15;
        barrel.incrementHealth = false;
    }
    private void SetOnFire(){
        healthBar.value-=Time.deltaTime*setOnFireDamage/barrelStats.Armor;
    }
    private void FrostArrow(){
        healthBar.value-=FrostArrowDamage/barrelStats.Armor;
        barrel.frostArrow=false;
    }


}
