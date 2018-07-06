using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeftCorpsesController : MonoBehaviour {
    private bool coll;

    private void Start()
    {
        coll = false;

    }
    void Update()
    {
        if (coll == false)
        {
            transform.Translate(Vector3.left * 6.0f * Time.deltaTime + Vector3.down * 16 * Time.deltaTime + Vector3.left * Time.deltaTime * 1.1f);
            transform.Rotate(0, 0, 35 * Time.deltaTime);
        }
        else
        {
            
            transform.Translate(Vector3.right * 0);
            transform.Rotate(0, 0, 0);
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "CorpsesStop")
        {
            coll = true;


        }
    }
}
