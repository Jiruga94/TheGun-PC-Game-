using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPlane : MonoBehaviour {

    public Transform healthPackage;
    
    public Transform dropPoint;
    

   
    
    public float speed = 0f;
    public Transform effect;
    private bool playMySound;

   
    void Start () {
       
        playMySound = false;
    }
	

	void Update () {

        transform.Translate(Vector3.right * speed * Time.deltaTime);
       
        }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       
    }
}
    

