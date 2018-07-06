using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour {
    public Transform respawnPoint;
    public GameObject player;
    private PlayerHealth playerHealth;
    private int spawnDelay = 3;
	void Start () {
       
        playerHealth = FindObjectOfType<PlayerHealth>();
	}
	
	// Update is called once per frame
	void Update () {
      
	}
   public IEnumerator RespawnPlayer()
    {
        yield return new WaitForSeconds(spawnDelay);
        Instantiate(player, respawnPoint.transform.position, respawnPoint.transform.rotation);


        Debug.Log("RESPAWN!!!");
    }
}
