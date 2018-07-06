using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Particlesove : MonoBehaviour {

    public Transform explosion;
	void Update () {
        transform.Translate(Vector3.left * Time.deltaTime * 2);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Destroyer")
        {
            Destroy(this.gameObject);
        }
        if (collision.tag=="Ground")
        {
            Transform explo = Instantiate(explosion, transform.position, transform.rotation);
            Destroy(explo.gameObject, 3.0f);
            Destroy(this.gameObject);
        }
    }
}
