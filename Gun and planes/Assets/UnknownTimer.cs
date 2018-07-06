using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class UnknownTimer : MonoBehaviour {

public GameObject[] gameObjects;
	public Text t;

	

	[SerializeField]private GameObject g1;

	[SerializeField]private GameObject g2;

[HideInInspector]
	public float unknowCount=0.0f;
	private float imControler=300.0f;
	private UnknownRespawn unknownRespawn;
	private float frostFogDuration;
	private HealthPlayerBySlider healthPlayerBySlider;
	public ParticleSystem particle;
	public bool stopTimeCount;

	private BigExplosion bigExplosion;
	[HideInInspector]public int c=0;
	private float secondfog=25;
private DoombringerController doombringerController;
[HideInInspector]public bool incrementhealth;
	private float timeToFog;
private AudioManager audioManager;
	[HideInInspector] public bool im;
	
	void Start () {
		incrementhealth=false;
		im=false;
		doombringerController=FindObjectOfType<DoombringerController>();
		bigExplosion=FindObjectOfType<BigExplosion>();
		healthPlayerBySlider=FindObjectOfType<HealthPlayerBySlider>();
		timeToFog=Random.Range(35,40);
		unknowCount=40.0f;
		unknownRespawn=FindObjectOfType<UnknownRespawn>();
		stopTimeCount=false;
		frostFogDuration=20;
		c=-1;
		//audioManager=AudioManager.instance;
		
	}
	
	void Update () {
	T();
	
						
			if(im==true)
			{

				g1.SetActive(true);
				g2.SetActive(true);
				
				im=false;
			}	
			
	
	}
	public void T(){
		unknowCount -=Time.deltaTime;
		t.text = "Unknown:" + Mathf.Round(unknowCount) + " seconds!";

		
        if (unknowCount <= 9.5)
        {
            t.text = "Unknown:" + "0" + Mathf.Round(unknowCount) + " seconds!";

            if (unknowCount <= 0)
            {
					
					
				
                t.text = "Unknown:" + "00" + " seconds!";
				c=0;
                unknowCount = 0;
				healthPlayerBySlider.restoreHp=true;
               imControler-=Time.deltaTime;
			  
			 if(gameObjects!=null){
				 for (int i = 0; i < gameObjects.Length; i++)
				   {
					  
					   gameObjects[i].SetActive(true);
					   
						
				   }
				  
			 }
			 
				  
				 frostFogDuration-=Time.deltaTime;
				
				
				   if(frostFogDuration<=0){
						frostFogDuration=0;
					
					   var ps=this.particle.GetComponent<ParticleSystem>().emission;
			 		ps.enabled=false;
					 
					 timeToFog-=Time.deltaTime;
					
					 if(timeToFog<=0){
						 timeToFog=0;
						 ps.enabled=true;
						incrementhealth=true;
						 secondfog-=Time.deltaTime;
						 
						 if(secondfog<=0){
							 incrementhealth=false;
							 ps.enabled=false;
							
							 secondfog=0;
						 }
					 }
				   }
				  
				  
				   }
				   
				   
				  
				  


            }
        }
     
    }
	

