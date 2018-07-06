using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheMGFireOp : MonoBehaviour {

    private int speed = 20;
    [SerializeField]
    private Transform hitPoint;
    [SerializeField]
    private Transform spark;
    void Update()
    {
       transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrel" || collision.tag == "Ground" || collision.tag == "SpaceShuttle")
        {

            Transform explosion = Instantiate(spark, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(explosion.gameObject, 0.5f);
            Destroy(this.gameObject);
        }
        if (collision.tag=="Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
