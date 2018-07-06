using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApacheRocketMoveOp : MonoBehaviour {

    private int speed = 20;
    [SerializeField]
    private Transform RocketExplosion;
    [SerializeField]
    private Transform hitPoint;
    private AudioManager am;

    void Update()
    {
        am = AudioManager.instance;
        transform.Translate(Vector3.right * Time.deltaTime * speed);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Barrel" || collision.tag == "Ground" || collision.tag == "SpaceShuttle")
        {
            am.PlaySound("ApacheRocketExplosion");
            Transform Rocket = Instantiate(RocketExplosion, hitPoint.transform.position, hitPoint.transform.rotation);
            Destroy(Rocket.gameObject, 1.0f);
            Destroy(this.gameObject);
        }
        if (collision.tag=="Destroyer")
        {
            Destroy(this.gameObject);
        }
    }
}
