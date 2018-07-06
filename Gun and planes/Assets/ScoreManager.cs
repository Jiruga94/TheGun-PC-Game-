using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ScoreManager : MonoBehaviour {

   
   public Text scoreText;
    public Text highScoreText;    
    private float scoreCount;
    [HideInInspector]
   public float highScoreCount;  
    [HideInInspector]
   public  float startScore = 0;
    private HighscoreManager hs;
    private float currentScore;
  

    private void Awake()
    {
            GameCotroller.scoreControl.Load();      
    }
    void Start()
    {
        scoreCount = 0;

            highScoreCount = GameCotroller.scoreControl.score;
            highScoreText.text = "Highscore:" + highScoreCount;
            scoreText.text = "Score:" + scoreCount;
            scoreCount = startScore;        
    }
    private void Update()
    {
       scoreText.text="Score:" + Mathf.Round(scoreCount);
       if(scoreCount<=0)
       {scoreCount=0;}
    }

    public void ScoreUpdate(int amount)
    {
        scoreCount +=amount;
          scoreText.text = "Score: " + Mathf.Round(scoreCount);
            if (GameCotroller.scoreControl.score < scoreCount)
            {
            
           GameCotroller.scoreControl.score = scoreCount;
            highScoreText.text = "Highscore : " + scoreCount;
            GameCotroller.scoreControl.Save();  
            }       
    }            
    }
        
      
    


