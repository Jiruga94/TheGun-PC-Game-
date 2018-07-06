using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
public class JoyStickController : MonoBehaviour {


private BarrelFire barrelFire;
public float moveForce=6,boostMultiplayer=2;
	Rigidbody2D myBody;
	void Start () {
		myBody=this.GetComponent<Rigidbody2D>();
		barrelFire=FindObjectOfType<BarrelFire>();
	}
	
		void FixedUpdate()
		{
			Vector2 moveVec=new Vector2(CrossPlatformInputManager.GetAxis("Horizontal"),CrossPlatformInputManager.GetAxis("Vertical"));
		
		Vector3 lookV=new Vector3(CrossPlatformInputManager.GetAxis("Horizontal_2"),CrossPlatformInputManager.GetAxis("Vertical_2"));
		transform.LookAt(lookV);

	bool isBoosting=CrossPlatformInputManager.GetButton("Boost");
	myBody.AddForce(moveVec*(isBoosting?boostMultiplayer:1));
}
}
