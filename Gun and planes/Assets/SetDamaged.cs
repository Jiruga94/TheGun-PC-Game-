using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetDamaged : MonoBehaviour {

    public GameObject DamagedBarrel;
	void Start () {
        DamagedBarrel.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
   
}
