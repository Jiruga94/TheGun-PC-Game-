using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayParticles : MonoBehaviour {

    [SerializeField]
    private Transform welderSparks;
    [SerializeField]
    private Transform welderCore;
    [SerializeField]
    private Transform zzzzzz;
    public Transform playPoint;
    public Transform secondPlayPoint;
    public Transform thirdPoint;

    void Start () {
        Transform playEffects = Instantiate(welderSparks,playPoint.transform.position,playPoint.transform.rotation);
        Transform playEffects2 = Instantiate(welderCore, playPoint.transform.position, playPoint.transform.rotation);
        Transform playEffects3 = Instantiate(zzzzzz, thirdPoint.transform.position, thirdPoint.transform.rotation);
    }

}
