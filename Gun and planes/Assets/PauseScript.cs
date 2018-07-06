using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour {
   
    public bool paused;
    int count = 0;
    
    public Image pauseText;

    public Text PriceText;
    public Image pauseText2;
    private EnemyStatistic enemyStatistic;
    public GameObject upgradePanel;
    public Text backToMenuText;
    public Image back;
    public Image respawnImageAfterDeath;
    public Image backtomenuImageAfterDeath;
    public Text resetTextAfterDeath;
    public Text backToMenuTextAfterDeath;
    private PlayerHealth playerHealth;
    private BarrelStats damaged;
    private bool restart;
    private GameCotroller gc;
    private Elite spaceGate;
    private AudioManager audiomanager;
    public GameObject upgradeImage;
    public Text upgradeText;
    public GameObject statisticButton;
    public bool goToStatistic;
    public GameObject statisticPanel;
    public float myTime = 0;
    private bool startgame;
    [SerializeField]private GameObject unknownTime;
    public Image goldImage;
    private ScoreManager sm;
    void Start () {
        startgame = true;
        statisticButton.SetActive(false);
        upgradePanel.SetActive(false);
        upgradeImage.SetActive(false);
        playerHealth = FindObjectOfType<PlayerHealth>();
        audiomanager = AudioManager.instance;
        paused = false;
        PriceText.enabled=false;
        back.enabled = false;
        pauseText.enabled = true;
        pauseText2.enabled = false;
        backToMenuText.enabled = false;
        respawnImageAfterDeath.enabled = false;
        backToMenuTextAfterDeath.enabled = false;
        resetTextAfterDeath.enabled = false;
        backtomenuImageAfterDeath.enabled = false;
        gc = FindObjectOfType<GameCotroller>();
        gc.Load();
        spaceGate = FindObjectOfType<Elite>();
        damaged = FindObjectOfType<BarrelStats>();
        goToStatistic = false;
        statisticPanel.SetActive(false);
        sm = FindObjectOfType<ScoreManager>();
	}
	
	void Update () {
        restart = false;
        TimeCount();
        if (playerHealth.stopGame==true)
        {
         Enabled();
        }
       

	}
  public void Enabled()
    {
          
        respawnImageAfterDeath.enabled = true;
        backtomenuImageAfterDeath.enabled = true;
        resetTextAfterDeath.enabled = true;
        backToMenuTextAfterDeath.enabled = true;
       
           Time.timeScale -= Time.deltaTime / 1.5f;
            if (Time.timeScale <= 0)
            {
                Time.timeScale = 0;
            }
        
       
    }
    public void TimeCount()
    {
        if (startgame == true)
        {
            myTime += Time.deltaTime;
          
        }
    }
    public void Pause() 
    {
        count++;
        if (count==1)
        {
         
            Time.timeScale = 0;
           pauseText.enabled = false;
           
            audiomanager.AudioPausedIsTrue();
            pauseText2.enabled = true;
            back.enabled = true;
            backToMenuText.enabled = true;
            upgradeImage.SetActive(true);
            statisticButton.SetActive(true);
            startgame = false;

        }
        else if (count == 2)
        {
           
            Time.timeScale = 1;
            count = 0;
            audiomanager.AudioPausedIsNotTrue();
            pauseText2.enabled = false;
            pauseText.enabled = true;
            back.enabled = false;
            backToMenuText.enabled = false;
            upgradeImage.SetActive(false);
            statisticButton.SetActive(false);
            startgame = true;
        }
    }
    public void BackToMenu()
    {
        audiomanager.StopAllSounds();
        backToMenuText.color = Color.black;
        backToMenuTextAfterDeath.color = Color.black;
        SceneManager.LoadScene(1);
        audiomanager.AudioPausedIsNotTrue();
        audiomanager.PlaySound("Welder");
        audiomanager.PlaySound("DesertNight");
        audiomanager.PlaySound("CampFire");
       
        Time.timeScale = 1;
    }
    public void GoToUpgrade()
    {
        SceneManager.LoadScene(3);
    }
       
    public void Respawn()
    {
        Time.timeScale = 1;
        resetTextAfterDeath.color = Color.black;
        restart = true;
        audiomanager.StopAllSounds();
        SceneManager.LoadScene(2);             
    }
    public void Disabled()
    {
        resetTextAfterDeath.enabled = false;
        respawnImageAfterDeath.enabled = false;
        backToMenuTextAfterDeath.enabled = false;
        backtomenuImageAfterDeath.enabled = false;
    }
    public void UpgradePanel()
    {
        statisticButton.SetActive(false);
        PriceText.enabled=true;
        upgradeText.color = Color.black;
        upgradePanel.SetActive(true);
        upgradeText.color = Color.white;
        goldImage.enabled = false;
        unknownTime.SetActive(false);
        
    }
    public void Statistic()
    {
        goToStatistic = true;
        unknownTime.SetActive(false);
        statisticPanel.SetActive(true);
        goldImage.enabled = false;
    }
    public void GoBackFromStats()
    {
        goToStatistic = false;
    unknownTime.SetActive(true);
        statisticPanel.SetActive(false);
        goldImage.enabled = true;

    }
    
    
}
