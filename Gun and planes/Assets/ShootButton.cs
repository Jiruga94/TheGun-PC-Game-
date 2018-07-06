using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShootButton : MonoBehaviour {

    public Button myButton;
    private BarrelFire bf;
	void Start () {
        myButton = GetComponent<Button>();
        bf = FindObjectOfType<BarrelFire>();
	}
	
	
	void Update () {
      
	}
    public void PointDown()
    {
        bf.Shoot();
            //Debug.Log("Wcisniety");
        
    }
}
