using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum SpawnState {respawnRocket,wait}
public class UnknownRespawn : MonoBehaviour {

	
	
	
	
	SpawnState spState;
	
	public bool stop;
	[Header("Details")]
	public float tbtw=3;
	private UnknownTimer unknownTimer;
	protected float currrentTimeBetweenWaves=0;
	public int myCount=0;
	
	public Transform[] spawnPoints;
	public Transform enemy;
	
	void Start(){
		
		currrentTimeBetweenWaves=tbtw;
		unknownTimer=FindObjectOfType<UnknownTimer>();
		spState=SpawnState.respawnRocket;
		stop=false;
		
	}
	void Update()
	{
		if(unknownTimer.unknowCount>0 &&unknownTimer.unknowCount<150)
		{
		SpawnPoints(enemy);
		}
	
	}	
	
		
	
	private void SpawnPoints(Transform enemy){

		if(stop==false&&spState==SpawnState.respawnRocket){
	
		
			Transform g=spawnPoints[Random.Range(0,spawnPoints.Length)];
			Instantiate(enemy,g.transform.position,g.transform.rotation);
				stop=true;
				spState=SpawnState.wait;
		}
		if(stop==true&&spState==SpawnState.wait) {
			tbtw-=Time.deltaTime;
			if(tbtw<=0){
				stop=false;
				tbtw=3;
				spState=SpawnState.respawnRocket;
			}
		}
	}}



	



