using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 enum ChargeRocket { charge,makeShoot}
enum MachineGunSpawn { shoot,wait}

public class ApacheController : MonoBehaviour {

   delegate void IndicatesGun();
    IndicatesGun indicates;
    private int speed = 3;
    [SerializeField]
    private Transform shootPoint;
    [SerializeField]
    private Transform rocket;
    [SerializeField]
    private Transform sparksAfterRocketshoot;
    [SerializeField]
    private Transform machineGun;
    [SerializeField]
    private Transform machineGunSpawner;
    [SerializeField]
    private Transform Husk;
    [SerializeField]
    private Transform machineGunFire;
    [SerializeField]
    private Transform huskPoint;
    [SerializeField]
    private Transform machineGunFirePoint;
    private WaitForSeconds chargeRocket;
    private float RocketRespawn=3;
    private float MachineGunRespawn=0;
    private bool Gun;
    private bool Rocket;
    private bool makeShoot;
    private float count = 1;
    private float tbs = 0;
    private float rotationZ = 1;
    ChargeRocket charge;
    MachineGunSpawn mgs;
    private bool startRotate;
    private float slowDown;
    public int currentHealth;
    public int maxHealth;
    private AudioManager audioManager;
    private bool startShooting;
    
    void Start () {
       
        
        startShooting = false;
        currentHealth = maxHealth;
        makeShoot = true;
        chargeRocket = new WaitForSeconds(1.0f);
        Rocket = true;
        startRotate = false;
        charge = ChargeRocket.makeShoot;
        slowDown = Random.Range(3, 5);
        audioManager = AudioManager.instance;
        audioManager.PlaySound("SecondHelicopterFly");
        startShooting = false;
        if (indicates!=null)
        {
            indicates();
        }  
    }
	void Update () {

       

        if (startRotate == false)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);
        }
        if (startRotate==true)
        {
            slowDown += Time.deltaTime;
            if (slowDown>10&&speed>=0)
            {
                speed -= (int)Time.deltaTime ;
            }
            transform.Translate(Vector3.left * Time.deltaTime*speed/slowDown);
            
            Count();
           
            if (count<2)
            {
                transform.Rotate(0, 0, rotationZ * Time.deltaTime * 14);
                speed = 0;
            }
        }
       
        if (RocketRespawn>0)
        {
            
            RocketRespawn -= Time.deltaTime;
            RocketAttack();
      
            if (RocketRespawn < 0)
            {
                Debug.Log("End rocket shooting!");
                RocketRespawn = 0;
                MachineGunRespawn = Random.Range(5, 10);
            }
        }
        
        if (MachineGunRespawn>0)
        {
            MachineGunAttack();
            MachineGunRespawn -= Time.deltaTime;
            if (MachineGunRespawn <= 0)
            {
                MachineGunRespawn = 0;
                RocketRespawn = Random.Range(4, 7);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="StartRotateApache")
        {
            startRotate = true;
            startShooting = true;
        }
       
    }
    public int _Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    IEnumerator RocketSpawn()
    {
        if (charge==ChargeRocket.makeShoot && tbs==0 && startShooting==true )
        {
          Transform shoot=Instantiate(rocket, shootPoint.transform.position, shootPoint.transform.rotation);
            Transform sparksAfterShoot = Instantiate(sparksAfterRocketshoot, shootPoint.transform.position, shootPoint.transform.rotation);
           audioManager.PlaySound("ApacheRocket");
            Destroy(sparksAfterShoot.gameObject, 1.0f);
            tbs = 0.5f;
            charge = ChargeRocket.charge;
           
        }
        
        if(charge==ChargeRocket.charge && tbs>0)
        {
            yield return new WaitForSeconds(tbs);
            charge = ChargeRocket.makeShoot;
            tbs = 0; 

        }



    }
    IEnumerator MachineGun()
    {
        if (mgs==MachineGunSpawn.shoot && startShooting == true)
        {
            Transform machneGun = Instantiate(machineGun,
              machineGunSpawner.transform.position, transform.rotation);
            Transform husks = Instantiate(Husk,huskPoint.transform.position,huskPoint.transform.rotation);
            Transform bulletMachineGunFire = Instantiate(machineGunFire, machineGunFirePoint.transform.position,machineGunFirePoint.transform.rotation);
            Destroy(husks.gameObject, 0.5f);
            Destroy(bulletMachineGunFire.gameObject, 0.3f);
            audioManager.PlaySound("ApacheMachineGun");
             mgs = MachineGunSpawn.wait;
        }
        if (mgs==MachineGunSpawn.wait)
        {
            yield return new WaitForSeconds(0.1f);
            mgs = MachineGunSpawn.shoot;
        }
       
       
    }
    public void Count()
    {
        count += Time.deltaTime;
       
    }
    public void RocketAttack()
    {


        if (charge == ChargeRocket.makeShoot )
        {
            StartCoroutine(RocketSpawn());
           
               
        }
       

    }
    public void MachineGunAttack()
    {
        if (mgs == MachineGunSpawn.shoot)
        {

            StartCoroutine(MachineGun());
        }
    }
    
}
