using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

   
 
    private BarrelStats destroyed;
   
    private SetDamaged damagedBarrel;
    [HideInInspector]
    public bool stopGame;
    public bool playSound;
    void Start()
    {
        
        stopGame = false;
        damagedBarrel = FindObjectOfType<SetDamaged>();
        playSound = false;
       
    }
   
   
    public void makeDead()
    {
       
        stopGame = true;
        playSound = true;
        damagedBarrel.DamagedBarrel.SetActive(true);
        this.gameObject.SetActive(false);
        
       
    }
   
}


