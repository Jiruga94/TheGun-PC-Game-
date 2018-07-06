using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomProtection2 : MonoBehaviour {

[HideInInspector]	public bool hit;
private int Health;

	[SerializeField]private StatusIndicator statusIndicator;
	private UnknownTimer unknownTimer;
	private DoombringerController doombringerController;
	private int currentHealth=0;
	private BarrelStats barrelStats;
	private int maxHealth=1000;
	public int _Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
	void Start () {
		doombringerController=FindObjectOfType<DoombringerController>();
		unknownTimer=FindObjectOfType<UnknownTimer>();
		_Health=maxHealth;
		barrelStats=FindObjectOfType<BarrelStats>();
		doombringerController.present2=true;
	}
	
		void Update () {
			if(statusIndicator!=null)
			{
				statusIndicator.SetHealth(currentHealth,maxHealth);
			}
		if(hit==true)
		{
			TakeDamage(barrelStats.damage);
			hit=false;
		}
		//doombringerController.present=true;
		
	}
	
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Bullet")
		{
			hit=true;

		}
	}
	private void TakeDamage(int damage)
	{
		_Health-=damage;
		if(_Health<=0)
		{
		_Health=0;
		unknownTimer.im=false;
		doombringerController.present2=false;
	//this.gameObject.SetActive(false);
	Destroy(this.gameObject);

		}
	}

}
