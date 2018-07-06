using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketEndHealth : MonoBehaviour {

	private AudioManager audioManager;
	private float currentHealth;
	private float health=150;
	private const int gold=40;
	private const int scorePoints=150;
	private GoldScript goldScript;
	private ScoreManager scoreManager;
	private BarrelStats barrelStats;
	[SerializeField]
	private Transform explosionEffect;
	public float Health{
		get {return currentHealth;}
		set{currentHealth=Mathf.Clamp(value,0,health);}
	}
	void Start () {
		goldScript=FindObjectOfType<GoldScript>();
		audioManager=AudioManager.instance;
		barrelStats=FindObjectOfType<BarrelStats>();
		scoreManager=FindObjectOfType<ScoreManager>();
		Health=health;
	}
	
		void Update () {
	
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Bullet"){
			
			TakeDamage(barrelStats.damage);
		}
	}
	public void TakeDamage(int damage)
	{
	Health-=barrelStats.damage;
	if(Health<=0){
		Health=0;
		Destroy(this.gameObject);
		audioManager.StopSound("EndRocketFly");
		Transform ee=Instantiate(explosionEffect,transform.position,transform.rotation);
		goldScript.GoldSalary(gold);
		scoreManager.ScoreUpdate(scorePoints);
		Destroy(ee.gameObject,0.5f);
}
	}
	
}
