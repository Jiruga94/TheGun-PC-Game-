using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDestroyed : MonoBehaviour {

	private AudioManager audioManager;
	void Start () {
		audioManager=AudioManager.instance;
		audioManager.PlaySound("Winter");
		audioManager.PlaySound("LowTone");
	}
	
	void Update () {
		transform.Translate(Vector3.left*Time.deltaTime*4);
	}
}
