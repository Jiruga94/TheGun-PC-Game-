using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelStats : MonoBehaviour {
 
    
    public int damage=0;
    public static BarrelStats barrelStats;
    
   
    private GameCotroller gs;
    public int minValue = 0;
    public int maxValue = 0;
    public float Armor = 1.0f;
    public int CriticalHitLow = 90;
    public int CriticalHitHigh = 110;
    public int ApacheRocketDamage=0;
    public int ApacheMGDamage =0;
    private PlayerHealth pl;
   
    [HideInInspector]
    public bool hitByBarrel;
    [HideInInspector]
    public bool criticalHit;
    private void Start()
    {
        minValue = 50;
        maxValue = 60;
        criticalHit = false;
        pl = FindObjectOfType<PlayerHealth>();
        ApacheMGDamage = 25;
        ApacheRocketDamage = 50;
    }
    void Update () {
        CriticalHit();     
	}
    void CriticalHit()
    {
        if (hitByBarrel==true)
        {
            int losowosc = Random.Range(1,100);
            if (losowosc>=1&&losowosc<=90)
            {
                damage = Random.Range(minValue, maxValue);
                hitByBarrel = false;
            } 
            else if(losowosc>=90 &&losowosc<=100)
            {
                criticalHit = true;
                damage = Random.Range(CriticalHitLow,CriticalHitHigh);
                hitByBarrel = false;
               
            }
           
        }
    }
}
