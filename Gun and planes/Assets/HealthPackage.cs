using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPackage : MonoBehaviour {


    private AudioManager audioManager;
    
    public string SoundName;
    private float health = -10;
    private bool RestoreHealth;
    [HideInInspector]
    public bool Health;
	void Start () {
        audioManager = FindObjectOfType<AudioManager>();
        
        
	}

	void Update () {
        RestoreHealth = false;
        Health = false;
	}
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="Barrel")
        {
          
            Destroy(gameObject);
           
            if (audioManager.wlacz == false)
            {
                audioManager.PlaySound(null);
            }
            if (audioManager.wlacz == true)

            {
                audioManager.PlaySound(SoundName);
            }
        }
    }
}
