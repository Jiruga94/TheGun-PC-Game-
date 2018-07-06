using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[System.Serializable]

public enum ShotingState { spwan,shoot}
public class LastBossController : MonoBehaviour {
   
   
   
   
    
    private ShotingState state = ShotingState.shoot;
    [SerializeField]
    private ParticleSystem greenP;
    [SerializeField]
    private ParticleSystem purpleP;
    [SerializeField]
    private GameObject AlienShield;
    private float TimeToShield=0;
    private float LifeDrainDuration=0;
    private Counter timer;
    private Animator animator;
    [SerializeField]
    private GameObject lifedrain;
    private BarrelFire bf;
    private ParticleSystem ps;
   
    private BarrelStats BarrelStats;
    private AudioManager audioManager;
    private SliderControl slider;
    public bool hit;
    public bool LDFElite;
    public bool shield;
    public bool isDead;
    public float rage = 0;
    private float r = -0.3f;
   
    private float g = 4.0f;
    void Start () {
        LDFElite = false;
        audioManager = AudioManager.instance;
        bf = FindObjectOfType<BarrelFire>();
        AlienShield.SetActive(false);
        state = ShotingState.spwan;       
        animator = GetComponent<Animator>();
        BarrelStats = FindObjectOfType<BarrelStats>();
        timer = FindObjectOfType<Counter>();
     
        LifeDrainDuration = Random.Range(4, 7);
        audioManager.PlaySound("PresentTime");
        rage = Random.Range(60,70);

        isDead = false;      
    }
	
	void Update () {
       AttackControl();
        

        animator.SetBool("Move", true);
//if elite isn't active time goes down to zero and then elite respawn
//time isn't constans, it's takes between two values
        if (timer.timeToappearsElite==0)
        {
            rage -=Time.deltaTime;
          //  Debug.Log("Time to active rage " + Mathf.Round(rage));
            if (rage<=0)
            {
             //after appear elite has a special time which countdown to zero an after it is rage time 
             //and special abilities will active 
                rage = 0;
               
                Debug.Log("Rage is active!!!!");
            }
            
        }
        if (rage==0)
        {
            greenP.gravityModifier = r;
            purpleP.gravityModifier = r;
            var fol = this.greenP.GetComponent<ParticleSystem>().forceOverLifetime;
            fol.enabled = true;
            var fols = this.purpleP.GetComponent<ParticleSystem>().forceOverLifetime;
            fols.enabled = true;
        }
      
     
      
    }
    public void  AttackControl()
    {
       
        if (LifeDrainDuration>0)
        {
            lifedrain.SetActive(true);
            LifeDrainDuration -= Time.deltaTime;
            bf.LifeDrainDamage = true;
            if (LifeDrainDuration<0)
            {
                
                audioManager.StopSound("UfoPresent");
                bf.LifeDrainDamage = false;
                lifedrain.SetActive(false);
                LifeDrainDuration = -1;
                TimeToShield = Random.Range(5, 7);
            }
        }
        if (TimeToShield>0)
        {
            
            AlienShield.SetActive(true);
            shield = true;
            TimeToShield -= Time.deltaTime;
           
            if (TimeToShield<0)
            {
                audioManager.StopSound("ShieldTime");
                audioManager.PlaySound("UfoPresent");
                TimeToShield = -1;
                AlienShield.SetActive(false);
                shield = false;
                LifeDrainDuration = Random.Range(5, 7);
            }
        }
    }
   

}
