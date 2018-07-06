using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticlesDown : MonoBehaviour {


	void Update () {
        transform.Translate(Vector3.down * -12 * Time.deltaTime);
    }
}
