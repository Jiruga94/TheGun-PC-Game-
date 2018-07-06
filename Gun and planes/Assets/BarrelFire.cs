using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelFire : MonoBehaviour {
   
    [HideInInspector]
    public bool LifeDrainDamage;
    [HideInInspector]
    public bool ApacheMachineGunHit;
    [HideInInspector]
    public bool BombHit;
    [HideInInspector]
    public float FireRate = 0;
    [HideInInspector]
    public bool ApacheRocket;
    [HideInInspector]
    public bool RocketHit;
    [HideInInspector]
    public bool herculesBombHit;
    [HideInInspector]
    public bool incrementHealth;
    [HideInInspector]
    public bool UfoDamage;
  
    public LayerMask whatToHit;
    public float timeToFire = 0;
    public Transform Bullet;
    Transform firePoint;
    float timeToSpawnEffect = 0;
    public float effectSpawnRate = 10;
    public Transform MuzzleEffectPrefab;
    Transform shootEffect;
  
    private AudioManager audioManager;
   
   [HideInInspector]public bool frostArrow;
 
    public string SoundName;
  


    [HideInInspector]public bool drainFrost;
 
    [HideInInspector]
    public bool HerculesBulletHit;
   
    public bool setOnFire;
    private BarrelStats bs;
    void Awake () {
       
        firePoint = transform.Find("ShootPoint");
        if (firePoint==null)
        {
            Debug.Log("NO TARGET");
           
        }
        shootEffect = transform.Find("ShootEffect");
        if (shootEffect==null)
        {
            Debug.Log("No shoot effect");
        }
	}
     void Start()
    {
        drainFrost=false;
        setOnFire=false;
        UfoDamage = false;
        HerculesBulletHit = false;
        herculesBombHit = false;
        incrementHealth = false;
        LifeDrainDamage = false;
        ApacheRocket = false;
        ApacheMachineGunHit = false;
        BombHit = false;    
        audioManager = AudioManager.instance;
        RocketHit = false;
        bs = FindObjectOfType<BarrelStats>();
       frostArrow=false;
    }
  
    void Update () {
        if (FireRate==0)
           {

               if (Input.anyKeyDown)
               {              
                   Shoot();
               }
           }
      

        else
        {
            if(Input.GetKeyDown(KeyCode.Space) && Time.time > timeToFire)
            {
              
              timeToFire = Time.time + 1 / FireRate;
               Shoot();
            }
        }
	}
    
  public void Shoot()
    {
        Vector2 mousePosition = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x, Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
        Vector2 firePointPosition = new Vector2(firePoint.position.x, firePoint.position.y);
       RaycastHit2D hit = Physics2D.Raycast(firePointPosition, mousePosition - firePointPosition,10,whatToHit);
       

        if (Time.time>=timeToSpawnEffect)
        {         
            Effect();
            timeToSpawnEffect = Time.time + 1 / effectSpawnRate;           
        }
     
            audioManager.PlaySound(SoundName);
        
        
        

    }
    void Effect()
    {
        Transform trail =Instantiate(Bullet, firePoint.position, firePoint.rotation)as Transform;       
        Transform clone = Instantiate(MuzzleEffectPrefab, shootEffect.position, shootEffect.rotation) as Transform;
        clone.parent= shootEffect;
        
        float size = Random.Range(0.6f, 0.9f);
        clone.localScale = new Vector3(size, size, size);      
        Destroy(clone.gameObject,0.02f);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
      
        if (collision.tag=="HealthBox")
        {
            
            Debug.Log("Naprawione!!!!");
        }
       
        if (collision.tag=="Rocket")
        {
            RocketHit = true;
        }
        if (collision.tag=="Bomb")
        {
            BombHit = true;
        }
        if (collision.tag=="ApacheBullet")
        {
            ApacheMachineGunHit = true;
        }
        if (collision.tag=="ApacheRocket")
        {
            ApacheRocket = true;
        }
        if (collision.tag == "LifeDrain")
        {
            LifeDrainDamage = true;
        }
      
        if (collision.tag=="HerculesBomb")
        {
            herculesBombHit = true;
        }
        if (collision.tag=="HerculesBulletHit")
        {
            HerculesBulletHit = true;
        }
        if (collision.tag=="HealthBox")
        {
            incrementHealth = true;
        }
        if(collision.tag=="FrostSpear")
        {

            frostArrow=true;
        }
        


    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "UfoDamage")
        {
            UfoDamage = true;
            
        }
        if(collision.tag=="EndExplosion"){
           setOnFire=true;
        }
        if(collision.tag=="DrainFrost")
        {
            drainFrost=true;
        }
   
        
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
       UfoDamage = false;
          setOnFire=false;
          drainFrost=false;
    }




}
