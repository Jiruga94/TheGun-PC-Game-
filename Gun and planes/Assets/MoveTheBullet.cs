using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheBullet : MonoBehaviour {

    
    private AudioManager audioSource;
    public string soundName;
    public int moveSpeed = 0;
    public Transform hitSparks;
    public Transform hitPoint;
    private AudioManager audioManager;
    private BarrelStats bs;
    public float myHitPoint = 0;
    
    private void Start()
    {
        audioManager = AudioManager.instance;
        audioSource = AudioManager.instance;
        audioSource = FindObjectOfType<AudioManager>();
        bs = FindObjectOfType<BarrelStats>();
        
    }
    void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * moveSpeed);
       
    }
    
     void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(this.gameObject,3.0f);
        if (collision.tag=="SpaceShuttle"||collision.tag=="Plane" || collision.tag=="Rocket"|| collision.tag=="Ufo"|| collision.tag=="Elite"||collision.tag=="Flip_X"||collision.tag=="Apache"||collision.tag=="FlipX"||collision.tag=="EndRocket"||collision.tag=="Doombringer"||collision.tag=="Accolyte")
        {
            bs.hitByBarrel = true;
            myHitPoint = hitPoint.transform.position.y;
            Transform hitEffect = Instantiate(hitSparks, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(hitEffect.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
        if (collision.tag=="AlienShield")
        {
            audioManager.PlaySound("HitShield");
            Destroy(this.gameObject);
        }
        if (collision.tag=="Destroyer")
        {
            Destroy(this.gameObject);
        }
        
    }
}
