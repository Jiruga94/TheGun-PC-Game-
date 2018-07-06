using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour {

   
    private int count = 0;
    public Canvas MainMenu;
    public Button startButton;
    public Button quitButton;
    private AudioManager audioManager;
    public string soundName;
    private HighscoreManager highScore;
    private GameObject audioSource;
    private Sound sound;
    public Image soundOn;
    public Image soundOff;
    [SerializeField]
    private Text startText;
    private BarrelStats bs;
    [SerializeField]
    private Text EnemiesText;
    [SerializeField]
    private Text QuitText;

    void Start () {
        
        bs = new BarrelStats();
        audioSource = GameObject.Find("AudioSource");
        audioSource.SetActive(true);
        audioManager = FindObjectOfType<AudioManager>();
        audioManager = AudioManager.instance;
        MainMenu = MainMenu.GetComponent<Canvas>();
        startButton = startButton.GetComponent<Button>();
        quitButton = quitButton.GetComponent<Button>();
        highScore = FindObjectOfType<HighscoreManager>();
        bs = FindObjectOfType<BarrelStats>();
        soundOff.enabled = false;
        audioManager.wlacz = true;
        if (audioManager.wlacz == false)
        {
            audioManager.PlaySound(null);
        }
        if (audioManager.wlacz == true)

        {
            audioManager.PlaySound("DesertNight");
            audioManager.PlaySound("Welder");
            audioManager.PlaySound("CampFire");
        }
        
    }
   
    public void StarGame()
    {
        startText.color = Color.black;
        Time.timeScale = 1;
        SceneManager.LoadScene(2);
        
        audioManager.StopSound("Welder");
        audioManager.StopSound("CampFire");
        audioManager.StopSound("DesertNight");
        Time.timeScale = 1;
     
        if (audioManager.wlacz == false)
        {
            audioManager.PlaySound(null);
        }
        if (audioManager.wlacz == true)

        {
            audioManager.PlaySound(soundName);
        }


    }
    public  void Highscore()
    {
        EnemiesText.color = Color.black;
        DontDestroyOnLoad(audioManager);
        SceneManager.LoadScene(3);
    }
    public void pusc()
    {
        count++;
        if (count==1)
        {

            audioManager.wlacz = false;
            soundOff.enabled = true;
            soundOn.enabled = false;
        }
        else if (count==2)
        {
            audioManager.wlacz = true;
            soundOff.enabled = false;
            soundOn.enabled = true;
            count = 0;
        }
        
        
    }
    
  
    public void QuitGame()
    {
       
        Application.Quit();

    }
}
