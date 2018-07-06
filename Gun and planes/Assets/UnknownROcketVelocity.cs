using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnknownROcketVelocity : MonoBehaviour {


	private float speed=0;
	public Transform eP;
	public Transform explosion;
	private AudioManager audioManager;
	void Start () {
		speed=15f;
		audioManager=AudioManager.instance;
		audioManager.PlaySound("EndRocketFly");
	}
	
		void Update () {
		transform.Translate(Vector2.down*speed*Time.deltaTime);
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Barrel"||other.tag=="Ground"){
			audioManager.StopSound("EndRocketFly");
			Transform e=Instantiate(explosion,eP.transform.position,explosion.transform.rotation);
			audioManager.PlaySound("BigRocketExplosion");
			Destroy(e.gameObject,3.0f);
			Destroy(this.gameObject);
		}
	}
}
