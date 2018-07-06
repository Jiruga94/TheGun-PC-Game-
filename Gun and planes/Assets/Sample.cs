using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {
    [SerializeField]
    private SpriteRenderer mySprite;
    Color32 myNewColor;
   // public Material DarkMaterial;   
    private Elite ls;
    EnemyStatistic es;
   public bool bright;
    private Color c;
    private Material sp;
    
    void Start()
    {
        
        sp = GetComponent<SpriteRenderer>().material;
        c = sp.color;
        bright = false;
        ls = FindObjectOfType<Elite>();
       //myNewColor = new Color32(86, 74, 74, 255);
        es = FindObjectOfType<EnemyStatistic>();
        
    }
	
	void Update () {

       
    }
    void Darkness()
    {
       if (ls.darkness == true)
        {
            mySprite.color = Color32.Lerp(mySprite.color, myNewColor, 0.0002f * Time.time);
            bright = true;
        }
       else if (bright==true)
        {
            Debug.Log("wszedlem do funkcji");
            mySprite.color =  Color32.Lerp(mySprite.color,c,0.03f*Time.time);
        }
    }
   
}
