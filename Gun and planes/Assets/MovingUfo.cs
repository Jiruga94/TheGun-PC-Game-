using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingUfo : MonoBehaviour {
    private UfoHealth ufohealth;
    private AudioManager audioManager;
    public string soundName;
    float speed;
    void Start()
    {
        ufohealth = FindObjectOfType<UfoHealth>();
        audioManager = FindObjectOfType<AudioManager>();
        speed = Random.Range(-1.4f, -1.6f);
        if (audioManager.wlacz == false)
        {
            audioManager.PlaySound(null);
        }
        if (audioManager.wlacz == true)

        {
            audioManager.PlaySound(soundName);
        }
    }

   
    void Update()
    {
      
        transform.Translate(Vector3.left * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Destroyer")
        {
            Destroy(gameObject);
            audioManager.StopSound("UfoLaser");
        }

    }
}
