using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigExplosion : MonoBehaviour {

		public bool explosion;
		private DoombringerController doombringerController;

		public GameObject bigExplosion;
		public Transform explosionPoint;
	void Start () {
		doombringerController=FindObjectOfType<DoombringerController>();
		explosion=false;
		
	}
	
		void Update () {
		StartCoroutine(E());
	}
	public  IEnumerator E(){
		if(explosion==true){
			yield return new WaitForSeconds(3.0f);
			
		bigExplosion.SetActive(true);
			explosion=false;
		}
	}
}
