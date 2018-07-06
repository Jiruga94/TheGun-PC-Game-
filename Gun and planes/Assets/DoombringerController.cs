using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoombringerController : MonoBehaviour {
	private BarrelStats barrelStats;
	[HideInInspector]public Animator animator;
	private GoldScript goldScript;
	private ScoreManager scoreManager;
	private const int goldSalary=10000;
	protected float timeToMove=5.0f;
	[HideInInspector]public float speed=1.5f;
	private const int scorePoints=5000;

	public GameObject rageEffect;
	private bool hit;

	private BigExplosion bigExplosion;

[HideInInspector]public bool present;

	private DoomBringerStop doomBringerStop;
	private float counter=3;
	public GameObject iceShaders;
	[HideInInspector]public int currentHealth;
	[SerializeField]
	private StatusIndicator statusIndicator;
	[SerializeField]private Transform iceShadersPoint;
	private UnknownTimer unknownTimer;
	private int g=0;
	private FrostController frostController;
	private const int maxHealth=40000;
	[HideInInspector]public bool stop;

	private Counter c;

	[HideInInspector]public int ValueOfRageAccess=30;

	[HideInInspector]public int halfLife=0;
	private AudioManager audioManager;
	[HideInInspector] public bool present2;

	
	public int _Health
    {
        get { return currentHealth; }
        set { currentHealth = Mathf.Clamp(value, 0, maxHealth); }
    }
	
	void Start () {
		unknownTimer=FindObjectOfType<UnknownTimer>();
		present2=false;
		present=false;
		c=FindObjectOfType<Counter>();
		hit=false;
		frostController=FindObjectOfType<FrostController>();
		stop=false;
		goldScript=FindObjectOfType<GoldScript>();
		scoreManager=FindObjectOfType<ScoreManager>();
		this.animator=GetComponent<Animator>();
		iceShaders.SetActive(false);
		barrelStats=FindObjectOfType<BarrelStats>();
		_Health=maxHealth;
			unknownTimer.stopTimeCount=true;
	audioManager=AudioManager.instance;
		  doomBringerStop=FindObjectOfType<DoomBringerStop>();
		  bigExplosion=FindObjectOfType<BigExplosion>();
		  	halfLife=_Health/2;
			 
		Debug.Log("Hf "+halfLife);
	
	}
	
	void Update () {
		c.contin=false;
		if(statusIndicator!=null){
			statusIndicator.SetHealth(currentHealth,maxHealth);
		}
		if(stop==false){
		StartCoroutine(Move());
		}
		
		else{

		speed=0;
		
		}
	
		if(present==false&&present2==false){
		if(hit==true){
		StartCoroutine(TakeDamage(barrelStats.damage));
			hit=false;
		}
		}
		if(g==0){
		Rage();
		}
		if(_Health<=halfLife)
		{
			unknownTimer.im=true;
			halfLife=-1;
		}
		if(g==1){
		
		
		}
		if(unknownTimer.incrementhealth==true)
		{
			_Health+=25;
		}
	}
	public IEnumerator TakeDamage(int damage){
			_Health-=damage;
			if(_Health<=0){
				audioManager.PlaySound("FrostDead");
				bigExplosion.explosion=true;
				_Health=0;
				goldScript.GoldSalary(goldSalary);
				scoreManager.ScoreUpdate(scorePoints);
				iceShaders.SetActive(true);
				
				yield return new WaitForSeconds(counter);
				
				audioManager.StopSound("LowTone");
				audioManager.PlaySound("MonsterDying");
				iceShaders.SetActive(false);
				Destroy(this.gameObject);
					
			}

	}
	private void Rage(){
		if(currentHealth<=ValueOfRageAccess){
			
			rageEffect.SetActive(true);
	g=1;
			
			
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if(other.tag=="Bullet"){
			hit=true;
		}
	
	}
	private IEnumerator Move(){
		yield return new WaitForSeconds(timeToMove);
		transform.Translate(Vector3.left*Time.deltaTime*speed);

	}
}
