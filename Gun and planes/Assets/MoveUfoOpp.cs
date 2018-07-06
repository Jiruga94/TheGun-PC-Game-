using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveUfoOpp : MonoBehaviour {

    float speed;
    private AudioManager audiomanager;
    void Start()
    {
        speed = Random.Range(1f, 1.6f);
        audiomanager = AudioManager.instance;
        audiomanager.PlaySound("UfoLaser2");
      
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
        }
    }
}
