using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsUI : MonoBehaviour {

    public Text highScoreText;
    public Text timeDurationText;
    public Text goldText;
    private GoldScript gs;
    private ScoreManager sc;
    private PauseScript pause;
    private StatsScript stats;
    int a,p,q,w,e,r=0;
    public Text amountOfApachesText;
    public Text amountOfSmallPlanesText;
    public Text amountOfSmallUfoText;
    public Text amountOfElitesText;
    public Text amountOfHerculesText;
    public Text amountOfSpaceShuttlesText;
    private PauseScript ps;
    
    void Start () {
        gs = FindObjectOfType<GoldScript>();
        sc = FindObjectOfType<ScoreManager>();
        pause = FindObjectOfType<PauseScript>();
        stats = FindObjectOfType<StatsScript>();
        ps = FindObjectOfType<PauseScript>();
        AmountOfDestroyedPlanes();

    }
    private void Update()
    {
        AmountOfDestroyedPlanes();
    }
    public void AmountOfDestroyedPlanes()
    {
        
        if (ps.goToStatistic==true)
        {

            
            amountOfElitesText.text = stats.myContent[stats.Elite].ToString();
            amountOfHerculesText.text = stats.myContent[stats.Hercules].ToString();
            amountOfSmallUfoText.text = stats.myContent[stats.SmallUfo].ToString();
            amountOfSpaceShuttlesText.text = stats.myContent[stats.SpaceShuttle].ToString();
            amountOfSmallPlanesText.text = stats.myContent[stats.SmallPlanes].ToString();
            amountOfApachesText.text = stats.myContent[stats.Apache].ToString();
            goldText.text = "Total conquered gold:"+ gs.totalGold.ToString();
            highScoreText.text = "HIGHSCORE:"+ sc.highScoreCount.ToString();
            timeDurationText.text ="Total time: "+Mathf.RoundToInt(pause.myTime).ToString()+" seconds";
        }
        else
        {
            amountOfApachesText.text = null;
        }
    }
}
