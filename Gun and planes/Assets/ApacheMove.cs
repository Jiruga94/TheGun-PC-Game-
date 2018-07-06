using System.Collections;
using System.Collections.Generic;
using UnityEngine;

enum ChargeR { charge, makeShoot }
enum MachineGunS { shoot, wait }

public class ApacheMove : MonoBehaviour {
    delegate void startFinding();
    startFinding sf;

    private float speed = 3;
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
    private AudioManager audioManager;
    private float RocketRespawn = 3;
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
    public float otherPointY = 0;
    private bool goingDown = false;
    private bool goingUp = false;
    private LeftApacheHp ApacheDown;
    void Start()
    {        
        ApacheDown = FindObjectOfType<LeftApacheHp>();
        ApacheDown.goingDown = false;
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
        audioManager.PlaySound("HelicopterFly");
        if (transform.position.y>0)
        {
            apachePositionY = transform.position.y;
            if (apachePositionY>sh.myPoint)
            {
                goingDown = true;
                goingUp = false;
            }
           else if (apachePositionY<sh.myPoint)
            {
                goingDown = false;
                goingUp = true;
            }
            Debug.Log("Apache position Y " + apachePositionY);
        }

    }
   
    void Update()
    {
       

        if (startRotate == false)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
        }
        if (startRotate == true)
        {
            slowDown += Time.deltaTime;
            if (slowDown > 10)
            {
                speed = 0;
            }
            transform.Translate(Vector3.right * Time.deltaTime * speed / slowDown);
            Count();

            if (count <3)
            {
                transform.Rotate(0, 0, -rotationZ * Time.deltaTime * 8);
                speed = 0;
            }
        }

        if (RocketRespawn > 0)
        {

            RocketRespawn -= Time.deltaTime;
            RocketAttack();

            if (RocketRespawn < 0)
            {
               
                RocketRespawn = 0;
                MachineGunRespawn = Random.Range(5, 10);
            }
        }
        if (stop == true)
        {
            speed -= Time.deltaTime;
            if (speed<=0)
            {              
                    GoingDown();
                    GoingUp();
            }
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
    public void GoingUp()
    {
        if (apachePositionY < sh.myPoint)
        {
            apachePositionY = transform.position.y;
            transform.Translate(Vector2.up * 0.5f * Time.deltaTime);
            if (apachePositionY == sh.myPoint && goingUp==true)
            {
                apachePositionY = transform.position.y;
                Debug.Log("pozycja apacza jest wieksza");
                transform.Translate(Vector2.up * 0.001f);
            }
        }
    }
    public void GoingDown()
    {
        speed = 0;
        if (apachePositionY > sh.myPoint)
        {
           
            apachePositionY = transform.position.y;
            transform.Translate(Vector2.down * 0.5f * Time.deltaTime);
            if (apachePositionY == sh.myPoint + 0.01f && goingDown==true)
            {
              //  apachePositionY = transform.position.y;
                Debug.Log("pozycja apacza jest mniejsza");
                transform.Translate(Vector2.down * 0);
            }
            else
            {
                transform.Translate(Vector2.down * 0);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "StartRotateApache")
        {
            startRotate = true;
            startShooting = true;
        }
        if (collision.tag=="slowDown")
        {
            Stop();
        }
    }
    public int _Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
    IEnumerator RocketSpawn()
    {
        if (charge == ChargeR.makeShoot && tbs == 0 && startShooting==true)
        {
            Transform shoot = Instantiate(rocket, shootPoint.transform.position, shootPoint.transform.rotation);
            Transform sparksAfterShoot = Instantiate(sparksAfterRocketshoot, shootPoint.transform.position, shootPoint.transform.rotation);
            audioManager.PlaySound("ApacheRocket");
            Destroy(sparksAfterShoot.gameObject, 1.0f);
            tbs = 0.5f;
            charge = ChargeR.charge;

        }

        if (charge == ChargeR.charge && tbs > 0)
        {
            yield return new WaitForSeconds(tbs);
            charge = ChargeR.makeShoot;
            tbs = 0;

        }



    }
    void Stop()
    {
        stop = true;
        currentPositionY = apachePositionY - sh.myPoint;
        Debug.Log("Difference " + currentPositionY);
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
    public void Count()
    {
        count += Time.deltaTime;

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

