using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Shootstate{shooting,reload};
public class FrostController : MonoBehaviour {

private AudioManager audioManager;
public Transform[] spawnPoints;

private DoombringerController doombringerController;
[HideInInspector]private bool stop=true;
Shootstate shoting;

[HideInInspector]public float waitTime=3.0f;
public Transform bullet;

		void Start()
	{
		audioManager=AudioManager.instance;
		shoting=Shootstate.shooting;
	}	
	
	void Update () {
		if(stop==true){
		StartCoroutine(StartShooting());
		}
	
	}
	public IEnumerator StartShooting(){

		if(shoting==Shootstate.shooting&& stop==true){
			audioManager.PlaySound("FrostArrow");
			Transform points=spawnPoints[Random.Range(0,spawnPoints.Length)];
			
			Instantiate(bullet,points.transform.position,points.transform.rotation);
			stop=false;
			shoting=Shootstate.reload;
		}
		 if(shoting==Shootstate.reload&&stop==false){

			yield return new WaitForSeconds(waitTime);
			stop=true;
			shoting=Shootstate.shooting;
			
		}

	
	}
}
