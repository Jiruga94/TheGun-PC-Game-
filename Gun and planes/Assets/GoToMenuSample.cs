using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GoToMenuSample : MonoBehaviour {
    public Text StartText;
    public Text EnemiesText;
    public Text QuitText;
    public Image soundOn;
    public Image soundOff;
    private AudioManager audioManager;
    
    private void Start()
    {
        audioManager = AudioManager.instance;
        audioManager.PlaySound("Welder");
        audioManager.PlaySound("CampFire");
        audioManager.PlaySound("DesertNight");
        audioManager.StopSound("FirstSceneSound");
        soundOff.enabled = false;
        if (audioManager.SoundON==false)
        {
            soundOff.enabled = true;
            soundOn.enabled = false;

        }
        else{ soundOff.enabled = false;
            soundOn.enabled = true;
        }

    }
    public void StartGame()
    {
        audioManager.StopSound("Welder");
        audioManager.StopSound("CampFire");
        audioManager.StopSound("DesertNight");
        StartText.color = Color.black;
        SceneManager.LoadScene(2);
    }
    public void Enemies()
    {
        EnemiesText.color = Color.black;
        SceneManager.LoadScene(3);
    }
    public void Quit1()
    {
        QuitText.color = Color.black;
        Application.Quit();
    }
    public void SoundOff()
    {
        audioManager.SoundON = false;
        soundOn.enabled = false;
        soundOff.enabled = true;
        audioManager.StopAllSounds();
    }
    public void SoundOn()
    {
        audioManager.SoundON = true;
        soundOn.enabled = true;
        soundOff.enabled = false;
        audioManager.PlaySound("Welder");
        audioManager.PlaySound("CampFire");
        audioManager.PlaySound("DesertNight");
        audioManager.StopSound("FirstSceneSound");
    }
    public void GuideButton()
    {
        SceneManager.LoadScene(3);
    }

}
