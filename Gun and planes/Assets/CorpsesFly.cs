
using UnityEngine;

public class CorpsesFly : MonoBehaviour {
    private bool coll;
    
    private void Start()
    {
        coll = false;
       
    }
    void Update () {
        if (coll==false)
        {
            transform.Translate(Vector3.right * 4f * Time.deltaTime+Vector3.down*16*Time.deltaTime+Vector3.right*Time.deltaTime*1.1f);
            transform.Rotate(0, 0, -35 * Time.deltaTime);
        }
        else
        {
            transform.Translate(Vector3.right * 0);
            transform.Rotate(0, 0, 0);
        }
       
	}
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="CorpsesStop")
        {
            coll = true;
            
            
        }
    }
}
