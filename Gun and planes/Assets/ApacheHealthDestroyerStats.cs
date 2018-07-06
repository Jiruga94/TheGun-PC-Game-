using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheHealthDestroyerStats : MonoBehaviour {

    private float speed =4;
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
    private ApacheHealth apacheDown;
    private WaitForSeconds chargeRocket;
    private AudioManager audioManager;
    private float RocketRespawn = 7;
    private float MachineGunRespawn = 0;
    private bool Gun;
    private bool Rocket;
    private bool makeShoot;
    private float count = 1;
    private float tbs = 0;
    private float rotationZ = 1;
    ChargeR charge;
    MachineGunS mgs;
    private bool startRotate;
    private float slowDown;
    private int currentHealth;
    private int maxHealth;
    private bool startShooting;
    private bool stop;
    private SpaceShuutleHealth sh;
    private float apachePositionY = 0.0f;
    private float currentPositionY = 0.0F;
    private float otherPointY = 0;
    private bool goingDown = false;
    private bool goingUp = false;
  
   
    void Start () {
       
        sh = FindObjectOfType<SpaceShuutleHealth>();
        stop = false;
        startShooting = false;
        audioManager = AudioManager.instance;
        currentHealth = maxHealth;
        makeShoot = true;
        chargeRocket = new WaitForSeconds(1.0f);
        Rocket = true;
        startRotate = false;
        charge = ChargeR.makeShoot;
        slowDown = Random.Range(3, 5);
        apacheDown=FindObjectOfType<ApacheHealth>();
        audioManager.PlaySound("HelicopterFly");
        if (transform.position.y > 0)
        {
            apachePositionY = transform.position.y;
           
        }
      
            Debug.Log("Apache position Y " + apachePositionY);
        
    }
	
	
	void Update () {
       
            transform.Translate(Vector2.up * Time.deltaTime*1.7f + Vector2.right * Time.deltaTime * speed);
            transform.Rotate(0, 0, -1.5f * Time.deltaTime);
        
      
      
        if (RocketRespawn > 0)
        {

            RocketRespawn -= Time.deltaTime;
            RocketAttack();

            if (RocketRespawn < 0)
            {
                Debug.Log("End rocket shooting!");
                RocketRespawn = 0;
                MachineGunRespawn = Random.Range(3, 4);
            }
        }
        if (stop == true)
        {
            speed -= Time.deltaTime;
           
        }

        if (MachineGunRespawn > 0)
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
        if (collision.tag == "slowDown")
        {
            Stop();
        }
        if (collision.tag=="Destroyer"||collision.tag=="SpaceShuttle")
        {
            audioManager.StopSound("HelicopterFly");
            Destroy(this.gameObject);
        }
        if (collision.tag=="StartShooting")
        {
            startShooting = true;
        }
        else if (collision.tag=="StopShooting")
        {
            startShooting = false;
        }
    }
    void Stop()
    {
        stop = true;
        currentPositionY = apachePositionY - sh.myPoint;
        Debug.Log("Difference " + currentPositionY);
    }
    IEnumerator RocketSpawn()
    {
        if (charge == ChargeR.makeShoot && tbs == 0 && startShooting == true)
        {
            Transform shoot = Instantiate(rocket, shootPoint.transform.position, shootPoint.transform.rotation);
            Transform sparksAfterShoot = Instantiate(sparksAfterRocketshoot, shootPoint.transform.position, shootPoint.transform.rotation);
            audioManager.PlaySound("ApacheRocket");
            Destroy(sparksAfterShoot.gameObject, 1.0f);
            tbs = 0.2f;
            charge = ChargeR.charge;

        }

        if (charge == ChargeR.charge && tbs > 0)
        {
            yield return new WaitForSeconds(tbs);
            charge = ChargeR.makeShoot;
            tbs = 0;

        }
    }
    IEnumerator MachineGun()
    {
        if (mgs == MachineGunS.shoot && startShooting == true)
        {
            Transform machneGun = Instantiate(machineGun,
              machineGunSpawner.transform.position, transform.rotation);
            Transform husks = Instantiate(Husk, huskPoint.transform.position, huskPoint.transform.rotation);
            Transform bulletMachineGunFire = Instantiate(machineGunFire, machineGunFirePoint.transform.position, machineGunFirePoint.transform.rotation);
            audioManager.PlaySound("ApacheMachineGun");
            Destroy(husks.gameObject, 0.5f);
            Destroy(bulletMachineGunFire.gameObject, 0.3f);
            mgs = MachineGunS.wait;
        }
        if (mgs == MachineGunS.wait)
        {
            yield return new WaitForSeconds(0.1f);
            mgs = MachineGunS.shoot;
        }


    }
    public void RocketAttack()
    {


        if (charge == ChargeR.makeShoot)
        {
            StartCoroutine(RocketSpawn());


        }


    }
    public void MachineGunAttack()
    {
        if (mgs == MachineGunS.shoot)
        {

            StartCoroutine(MachineGun());
        }
    }
   
}
