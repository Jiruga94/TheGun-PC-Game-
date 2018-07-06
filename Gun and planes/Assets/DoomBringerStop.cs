using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoomBringerStop : MonoBehaviour {

	private DoombringerController doombringerController;
	private AudioManager audioManager;
	
	

	public Transform ePoint;

	public bool OnExplosion;
	public GameObject[] gameO;

	public Transform bigExplosion;

	
	void Start () {
		OnExplosion=false;
		for (int i = 0; i < gameO.Length; i++)
		{
			gameO[i].SetActive(false);
		}
		audioManager=AudioManager.instance;
		doombringerController=FindObjectOfType<DoombringerController>();
		
	}

		void Update()
	{
		if(OnExplosion==true){
			Transform ex=Instantiate(bigExplosion,ePoint.transform.position,ePoint.transform.rotation);
			Destroy(ex.gameObject,1.0f);

		}
	}
	
	
	void OnTriggerEnter2D(Collider2D other)
	{
		
		if(other.tag=="StopDoombringer"){
			Debug.Log("Stop");
			audioManager.PlaySound("MonsterNoise");
			doombringerController.stop=true;
			doombringerController.animator.SetBool("LookDown",true);
			for (int i = 0; i <gameO.Length; i++)
			{
				gameO[i].SetActive(true);
			}
		}
	}

}
