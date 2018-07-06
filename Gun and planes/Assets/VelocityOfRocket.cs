using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VelocityOfRocket : MonoBehaviour {

    // Use this for initialization
    public float speed = 0;
    public Transform firePoint;
    public Transform fire;
  


    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Bullet")
        {
            Destroy(gameObject);
        }
        if (collision.tag == "Barrel")
        {
            Destroy(gameObject);
        }
    }

    void Update () {
       transform.Translate(Vector3.down * speed * Time.deltaTime);
       
     
    }
   
}
