using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastingLaser : MonoBehaviour {
    

    [SerializeField]
    private Transform laserdirection;
    [SerializeField]
    private Transform laserend;
   	
	void Update () {
        Laser();
    }
    public void Laser()
    {
      
        Vector2 laserEnd = new Vector2(laserend.transform.position.x, laserend.transform.position.y);
      
        Vector3 Direction = new Vector3(laserdirection.transform.position.x, laserdirection.transform.position.y, laserdirection.transform.rotation.z);
        

         RaycastHit2D hit=Physics2D.Raycast(Direction,laserEnd);
         if (hit.collider.tag=="Barrel")
         {
             Vector3 hitPoint = new Vector3(hit.point.x,laserdirection.transform.position.y,laserdirection.transform.rotation.z);
             Debug.DrawLine(Direction, hitPoint,Color.green);

         }
         if (hit.collider.tag != "Barrel"|| hit.collider.tag != "SpaceShuttle")
         {
             Debug.DrawLine(Direction, laserEnd, Color.green);
         }

    }
    
       

}
