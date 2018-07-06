using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CampFireLight : MonoBehaviour {
    [SerializeField]
    private Light lightining;
    private float range = 3.5f;
	void Start () {
        lightining.range = range;
    }
	
	
	void Update () {
        // float amplitude = Mathf.PingPong(Time.time, 4.0f);
        //amplitude = amplitude / 4.0f * 0.5f + 0.5f;
       
    }
}
