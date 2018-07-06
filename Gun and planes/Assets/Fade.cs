using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Fade : MonoBehaviour
{
 
  
   private SpriteRenderer spriteRenderer;
    private Color col = Color.black;
    float x = 0;
    private UnknownTimer unknownTimer;
    Color32 color32;
    void Start()
    {
        color32=new Color32(90,90,90,255);
    
       unknownTimer=FindObjectOfType<UnknownTimer>();
       spriteRenderer=this.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if(unknownTimer.unknowCount<=0)
        {
    FadeTime();
        }
       
     
    }
    public void FadeTime()
    {
        
      
       spriteRenderer.color=Color32.Lerp(spriteRenderer.color,color32,Time.deltaTime);
        
        
       
      /*  if (Time.timeSinceLevelLoad<fadeTime)
        {
            float p = Time.deltaTime / fadeTime;
            col.a -= p;
            image.color = col;
        }
        else
        {
            this.gameObject.SetActive(false);
        }
        */
    }
  
       
    }

