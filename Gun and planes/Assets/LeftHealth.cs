using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftHealth : MonoBehaviour
{
    private AudioManager audiomanager;
    private bool release;
    private HealthPlane healthPlane;
    void Start()
    {
        healthPlane = FindObjectOfType<HealthPlane>();
        release = false;
        audiomanager = AudioManager.instance;
    }

 
    void Update()
    {
        if (release == true)
        {
            if (healthPlane.speed > 0)
            {
                healthPlane.speed -= Time.deltaTime*2;

                if (healthPlane.speed <= 0)
                {
                  

                    Transform dropPlace = Instantiate(healthPlane.healthPackage, healthPlane.dropPoint.position, healthPlane.dropPoint.rotation) as Transform;
                    release = false;
                    healthPlane.speed += Time.deltaTime * 175.0f;
                   
                }

            }
        }
    }
        
    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.tag == "Slow")
        {
            release = true;

        }
        if (collision.tag=="Destroyer")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "PlaySound")
        {
            audiomanager.PlaySound("SpaceShuttleSlowDown");
        }
       
    }
}
