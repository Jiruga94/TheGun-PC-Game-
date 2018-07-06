using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceShipFire : MonoBehaviour {

   public Transform firePoint;
   public Transform firePoint2;
   public Transform firePoint3;
    public Transform bullet;
    public float timeCounting = 0;
    void Awake()
    {
        firePoint.transform.Find("firePoint");
        if (firePoint==null || firePoint2==null || firePoint3==null)
        {
            Debug.Log("No fire points in spaceship");
        }
    }
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        timeCounting -= Time.deltaTime;
        Debug.Log("Counting started...." + timeCounting);
        if (timeCounting<=0)
        {
            Debug.Log("zero!!!");
        
         

        }
        
	}
   
}
