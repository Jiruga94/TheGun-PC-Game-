using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletHrc : MonoBehaviour {

    private int speed = 20;
    [SerializeField]
    private Transform hitPoint;
    [SerializeField]
    private Transform sparks;
    private bool hitByHrcBull;
   
    

    
    void Update () {
        transform.Translate(Vector3.right * speed * Time.deltaTime);
        hitByHrcBull = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ground"||collision.tag=="Barrel")
        {
            Transform explosion = Instantiate(sparks, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(this.gameObject);
            Destroy(explosion.gameObject, 0.5f);
           
        }
        if (collision.tag=="Destroyer")
        {
            Destroy(this.gameObject);
        }
      
    }

}
