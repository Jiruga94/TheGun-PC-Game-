using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour {
    public Rigidbody2D bulletPrefab;
    public float attackSpeed = 0.2f;
    public float bulletSpeed = 600.0f;
    public Transform shootPoint;
    private float coolDown;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time>=coolDown)
        {
            if (Input.GetMouseButton(0))
            {
                Fire();
            }
        }
	}
    void Fire()
    {
        Vector3 mousePosition = Input.mousePosition;
        Vector3 screenPosition = Camera.main.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, transform.position.z - Camera.main.transform.position.z));
        Quaternion q = Quaternion.FromToRotation(Vector3.up, screenPosition - transform.position);

        Rigidbody2D bullet;
        if (transform.localScale.x < 0)
        {
            bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x - shootPoint.localPosition.x, transform.position.y - shootPoint.localPosition.y, transform.position.z), q) as Rigidbody2D;
        }
        else
        {
            bullet = Instantiate(bulletPrefab, new Vector3(transform.position.x + shootPoint.localPosition.x, transform.position.y + shootPoint.localPosition.y, transform.position.z), q);
        }
        bullet.GetComponent<Rigidbody2D>().AddForce(bullet.transform.up * bulletSpeed);
        coolDown = Time.time + attackSpeed;
    }
}
