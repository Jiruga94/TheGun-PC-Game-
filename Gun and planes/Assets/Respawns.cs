using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Respawns : MonoBehaviour {

	public GameObject[] gameO;
	public GameObject monster;

	public GameObject myPanel;
	
	BigExplosion bigExplosion;
	void Start () {
		bigExplosion=FindObjectOfType<BigExplosion>();
		monster.SetActive(true);
		for (int i = 0; i < gameO.Length; i++)
		{
		gameO[i].SetActive(false);
		}
	
	}

	void Update()
	{
			if(bigExplosion.explosion==true){
				StartCoroutine(EndGame());
		
		}
		
	}
	public IEnumerator EndGame(){

		yield return new WaitForSeconds(6.0f);
	
		myPanel.SetActive(true);

	}
	

	
		
}
