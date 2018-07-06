using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;
public enum ShootState {shoot,wait}
public enum BombState { drop, recharge }
public class MoveHrc : MonoBehaviour {
    private int speed = 50;
    public Transform smoke;
    public Transform Ignite;
    public Transform[] SpawnPoints;  
    private bool shoot;
    private float timeBtwShoot;
    private bool w;
    [HideInInspector]
    public float move = 5.0f;
    public GameObject Polygon1;
    public GameObject Polygon2;
    [HideInInspector]
    public bool flip;
    public SpriteRenderer mySprite;
   
    private HerculesHealth herculesHealth;
    private float rotationZ=1.5f;
    [HideInInspector]
    public float moveForce;
    ShootState s;
    BombState b;
    [SerializeField]
    private GameObject Fire;
    [SerializeField]
    private GameObject Fire2;
    [SerializeField]
    private GameObject Fire3;
    [SerializeField]
    private GameObject Fire4;
    [SerializeField]
    private GameObject Fire5;
    [SerializeField]
    private GameObject Fire6;
    [SerializeField]
    private GameObject Sparks;
    [SerializeField]
    private GameObject Sparks2;
    [SerializeField]
    private GameObject Sparks3;
    [SerializeField]
    private Transform BombRespawn;
    [HideInInspector]
    public bool Dive;
    private Rigidbody2D rg;
    [SerializeField]
    private Transform secondRespawnPoint;
    [SerializeField]
    private Transform bomb;
    private bool dropIt;
    private float timeBtwDrop;
    private bool OutOfRange;
    private AudioManager audioManager;

    void Start () {
        audioManager = AudioManager.instance;
        dropIt = true;
        Dive = false;
        s = ShootState.shoot;
        timeBtwShoot = 0;
        w = true;
        Polygon2.SetActive(false);
        Polygon1.SetActive(true);
        mySprite = GetComponent<SpriteRenderer>();
        flip = false;
        herculesHealth = FindObjectOfType<HerculesHealth>();
        moveForce = Random.Range(4.5f, 8.5f);
        Fire.SetActive(false);
        Fire2.SetActive(false);
        Fire3.SetActive(false);
        Sparks.SetActive(false);
        Sparks2.SetActive(false);
        Sparks3.SetActive(false);
        Fire4.SetActive(false);
        Fire5.SetActive(false);
        Fire6.SetActive(false);
        rg = GetComponent<Rigidbody2D>();
        timeBtwDrop = Random.Range(0.5f, 1f);
        audioManager.PlaySound("HerculesFlying");
    }

    
    void Update () {
        StartCoroutine(dropBomb());
        if (w==true)
        {
            StartCoroutine(Shoot());
        }
         if (flip ==false)
         {
             BombRespawn.transform.localPosition = new Vector3(-0.25f, -0.571f, 0f);
           
             transform.Translate(Vector3.left * move * Time.deltaTime/5);
         }
         else if (flip==true)
         {
             BombRespawn.transform.localPosition = new Vector3(0.295f, -0.571f, 0f);

            
             transform.Translate(Vector3.right * move * Time.deltaTime/5);
         }

      

        if (herculesHealth.alive == false)
        {
            Sparks.SetActive(true);
            Sparks2.SetActive(true);
            Sparks3.SetActive(true);
            rg.gravityScale = 0.09f;
            if (flip == true && herculesHealth._Health <= 0)
            {
                BombRespawn.transform.localPosition = new Vector3(0.295f, -0.571f, 0f);
               
                Dive = true;
                Fire4.SetActive(true);
                Fire5.SetActive(true);
                Fire6.SetActive(true);
                transform.Translate(-Vector3.left * move * Time.deltaTime / 5);
                transform.Rotate(0, 0, -rotationZ * Time.deltaTime * moveForce);
                
            }
            else if (flip == false && herculesHealth._Health <= 0)
            {
             
                BombRespawn.transform.localPosition = new Vector3(-0.25f, -0.571f, 0f);
                Dive = true;
                Fire.SetActive(true);
                Fire2.SetActive(true);
                Fire3.SetActive(true);
                transform.Translate(Vector3.left * move * Time.deltaTime / 5);
                transform.Rotate(0, 0, rotationZ * Time.deltaTime * moveForce);
                
            }
            
        }
        if(transform.position.x >= 4.89f || transform.position.x <= -4.89f)
        {
            OutOfRange = true;
          
        }
        else
        {
            OutOfRange = false;
            
        }


    }
    public IEnumerator Shoot()
    {
       
        if (s==ShootState.shoot && w==true && Dive==false)
            {
               
                Transform Rand = SpawnPoints[Random.Range(0, SpawnPoints.Length)];
                 audioManager.PlaySound("HerculesShoot");
                Instantiate(Ignite, Rand.transform.position, Rand.transform.rotation);
                 Transform Smoke = Instantiate(smoke, Rand.transform.position, Rand.transform.rotation);
                    Destroy(Smoke.gameObject, 0.6F); 
          
                timeBtwShoot = 1.6f;

                s = ShootState.wait;
            
                 w = false;
          
        }
      
             if (s==ShootState.wait && w==false)
            {
                    yield return new WaitForSeconds(timeBtwShoot);
                    timeBtwShoot = 0;
                    s = ShootState.shoot;
                        w = true;
        }

        }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="FlipX")
        {
            
            Flip();
        }
         if (collision.tag =="Flip_X")
        {
            
            Flip_X();
        }
    }
    public void Flip()
    {
       
        flip = false;
       
        Polygon2.SetActive(false);
        Polygon1.SetActive(true);
        mySprite.flipX = false;
    }
    public void Flip_X()
    {
        flip = true;
        mySprite.flipX = true;
       
        Polygon2.SetActive(true);
        Polygon1.SetActive(false);
    }
        

    public IEnumerator dropBomb()
    {
        b = BombState.drop;
        if (b==BombState.drop)
        {
            if (flip == false && herculesHealth._Health > 0 && dropIt==true)
            {
                Transform drop = Instantiate(bomb, BombRespawn.transform.position, BombRespawn.transform.rotation);
                dropIt = false;
                b=BombState.recharge;
            }
               else if(flip == true && herculesHealth._Health > 0 && dropIt == true)
            {


                Transform drop = Instantiate(bomb, secondRespawnPoint.transform.position, secondRespawnPoint.transform.rotation);
                dropIt = false;
                b = BombState.recharge;
            }
        }
        if(dropIt==false && b==BombState.recharge)
        {
            yield return new WaitForSeconds(timeBtwDrop);
            b = BombState.drop;
            dropIt = true;
        }

    }
 


    }


    

