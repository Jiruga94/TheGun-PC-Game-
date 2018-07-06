using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class BackFromUpdate : MonoBehaviour {

    private BarrelStats bs;
    public Text lowDamageText;
    public Text highDamageText;
    public Image highDamageImage;
    public Image lowDamageImage;
    private GameCotroller gs;
	void Start () {
        gs = FindObjectOfType<GameCotroller>();
        bs = FindObjectOfType<BarrelStats>();
        Update();
        UpgradeMyStats();
    }
	
	// Update is called once per frame
	void Update () {
        lowDamageText.text = "Low: " +bs.minValue;
        highDamageText.text = "High : " +bs.maxValue;
        
    }
    public void BackToGame()
    {
       
        SceneManager.LoadScene(1); 
    }
    public void UpgradeMyStats()
    {
       bs.minValue = +1;    
       
    }
    public void Upgrade()
    {
      bs.maxValue += 1;
       
    }
}
