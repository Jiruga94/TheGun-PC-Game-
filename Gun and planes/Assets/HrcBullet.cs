using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HrcBullet : MonoBehaviour {
    [SerializeField]
    private Transform sparks;
    [SerializeField]
    private Transform hitPoint;
    [HideInInspector]
    public int damage = 15;
    public bool HitByBullet;
    private AudioManager audiomanager;

    private void Update()
    {
        HitByBullet = false;
    }
    private void Start()
    {
        audiomanager = AudioManager.instance;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Ground" || collision.tag == "Bullet")
        {

            Transform explosion = Instantiate(sparks, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(explosion.gameObject, 0.5f);
            Destroy(this.gameObject);
            audiomanager.PlaySound("HerculesBombExplosion");

        }
        else if(collision.tag == "Barrel")
        {
            Transform explosion = Instantiate(sparks, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(explosion.gameObject, 0.5f);
            HitByBullet = true;
            audiomanager.PlaySound("HerculesBombExplosion");
            Destroy(this.gameObject);
        }
      
        if (collision.tag == "Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
