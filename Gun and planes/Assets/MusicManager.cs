using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour {

    public AudioClip[] levelMusicChangeArray;
    private AudioSource audioSource;
     void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    // Update is called once per frame
    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }
    void OnLevelWasLoaded(int level)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[level];
        Debug.Log("Playing clip: " + levelMusicChangeArray[level]);
        if (thisLevelMusic)
        {
            audioSource.clip = thisLevelMusic;
            audioSource.loop = true;
            audioSource.Play();
        }
    }
    // Update is called once per frame
    void Update () {
		
	}
}
