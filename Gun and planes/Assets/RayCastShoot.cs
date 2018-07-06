using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RayCastShoot : MonoBehaviour {

    private LineRenderer lineR;
  
    public Transform laserLine;
  
	void Start ()
    {
        lineR = GetComponent<LineRenderer>();
        lineR.enabled = true;
        lineR.useWorldSpace = true;
        	
	}
	
	
	void Update () {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.up);
        Debug.DrawLine(laserLine.transform.position,laserLine.position,Color.green);
        laserLine.position = -hit.point.normalized;
        lineR.SetPosition(0, transform.position);
        lineR.SetPosition(1, laserLine.position);
    

    }
   
}
