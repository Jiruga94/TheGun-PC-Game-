﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class WinterBullets : MonoBehaviour {

	public Transform hitPoint;
	public Transform exp;
void Update () {
		transform.Translate(Vector3.right*Time.deltaTime*30);
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Ground"||other.tag=="Barrel"){
			Transform e= Instantiate(exp,hitPoint.transform.position,hitPoint.transform.rotation);
			
			Destroy(this.gameObject);
			Destroy(e.gameObject,1.5f);
		}
		if(other.tag=="Destroyer"){
			Destroy(this.gameObject);
		}
	}
}
	