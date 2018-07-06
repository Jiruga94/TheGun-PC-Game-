using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class SliderControl : MonoBehaviour {
  
   
    public Slider slider;
    private LastBossController ls;

    private Elite elite;
    private Counter counter;
   
	void Start () {
       
        ls = FindObjectOfType<LastBossController>();
        elite = FindObjectOfType<Elite>();
        slider = GetComponent<Slider>();
      
        slider.maxValue = Random.Range(200, 399);
        slider.value = slider.maxValue;
        Debug.Log("Current health of elite: "+slider.value);
        counter = FindObjectOfType<Counter>();
        slider.enabled = true;

    }
	
	// Update is called once per frame
	void Update () {
       
     
        if (ls.hit==true)
        {
            slider.value -= 20;
            if (slider.value<=0)
            {
                ls.isDead = true;
                slider.value = 0;
                
              
            }
            return;
        }
	}
    
}
