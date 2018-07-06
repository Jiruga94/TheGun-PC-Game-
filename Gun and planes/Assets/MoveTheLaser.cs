using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTheLaser : MonoBehaviour {

    private int speed = 6;
    public Transform sparks;
    public Transform HitPoint;
    public bool HitByAlien;
	
	void Update () {
        transform.Translate(Vector3.down * speed * Time.deltaTime);
        HitByAlien = false;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Ground")
        {
            
        Transform spark=Instantiate(sparks, HitPoint.transform.position, HitPoint.transform.rotation);
           
            
            Destroy(this.gameObject);
           Destroy(spark.gameObject,0.08f);
         
        }
        if (collision.tag=="Barrel")
        {
            HitByAlien = true;
            Transform spark = Instantiate(sparks, HitPoint.transform.position, HitPoint.transform.rotation);


            Destroy(this.gameObject);
            Destroy(spark.gameObject, 0.08f);
        }
    }
}
