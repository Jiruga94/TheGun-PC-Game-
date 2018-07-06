using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointLight : MonoBehaviour {

    [SerializeField]
    private Light pointLight;
    public float range;
    public float range2;
    Color c;
	void Update () {
        
        pointLight.range = Random.Range(range, range2);
        c = Color.Lerp(Color.white, Color.blue, Mathf.PingPong(Time.time, 1));
    }
}
