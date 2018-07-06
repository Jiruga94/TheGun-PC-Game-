using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelOfGun : MonoBehaviour {

    // Use this for initialization
   
    
  public int rotationOffSe = 90;
    
  
    void Update()
    {
        
      Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();
        float rotation = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
     transform.rotation = Quaternion.Euler(0f, 0f, rotation + rotationOffSe);
    }
  
}
