
using UnityEngine;

public class ReleaseHealth : MonoBehaviour {

    private bool secondRelease;
    private HealthPlane healthPlane;
    AudioManager audioManager;
    void Start () {
        healthPlane = FindObjectOfType<HealthPlane>();
        secondRelease = false;
        audioManager = AudioManager.instance;
	}
	

	void Update () {
        if (secondRelease == true)
        {
            if (healthPlane.speed < 0)
            {
                healthPlane.speed += Time.deltaTime*2.0f;
                if (healthPlane.speed >= 0)
                {
                    Debug.Log("ZERO");

                    Transform dropPlace = Instantiate(healthPlane.healthPackage,healthPlane.dropPoint.position, healthPlane.dropPoint.rotation) as Transform;
                    secondRelease = false;
                    healthPlane.speed -= Time.deltaTime * 175.0f;
                }
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag=="SecondSlow")
        {
            secondRelease = true;
        }
        if (collision.tag=="Destroyer")
        {
            Destroy(gameObject);
        }
        if (collision.tag=="StopSound")
        {
            audioManager.PlaySound("SpaceShuttleSlowDown");
        }
    }
}
