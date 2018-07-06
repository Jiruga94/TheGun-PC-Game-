using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class HighscoreManager : MonoBehaviour {

    private AudioManager audioManager;

    public Text firstPositionText;
    public Text secondPositionText;
    public Text thirdPositionText;

    private float highScore;
    private GameCotroller gc;
    
    void Start () {
        gc = new GameCotroller();
      
     
        firstPositionText.text = "1 ";
      
        audioManager = FindObjectOfType<AudioManager>();
	}
	
	void Update () {
       
	}
    public void Back()
    {
       // GameCotroller.scoreControl.Save();
        DontDestroyOnLoad(audioManager);
        SceneManager.LoadScene(0);
        
    }
   
}
