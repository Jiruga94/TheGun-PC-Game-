using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheFirstSceneVelocity : MonoBehaviour {
	void Update () {
        transform.Translate(Vector3.right * Time.deltaTime * 4f);
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
