using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeController : MonoBehaviour {

      public Text damageLowText;
      public Text damageHighText;
      public Text CriticalLowText;
      public Text CriticalHighText;
      public Text armorText;   
      private BarrelStats bs;
    public Text priceText;
      [SerializeField]private GameObject unknownTime;
      public Button incrementlMaxValue;
      public Button incrementMinValue;
      public Button incrementArmorButton;
    private PauseScript ps;
      private GoldScript goldScript;
      public Button OkButton;
      public Text errorText;
    public Text goldText;
      private string logError = "Warning, min value cannot be higher than max value!";
    private bool logE;
    public GameObject panel;
    private string NotEnough="Not enough gold to upgrade your abilities!";
    private string nothing = "";
    
	void Start () {
      
        logE = false;
        goldScript = FindObjectOfType<GoldScript>();
        bs = FindObjectOfType<BarrelStats>();
        ps = FindObjectOfType<PauseScript>();
       
	}
    private void Update()
    {
        damageLowText.text = bs.minValue.ToString();
        damageHighText.text = bs.maxValue.ToString();
        armorText.text =((bs.Armor*100)/100).ToString(); 
        CriticalLowText.text = bs.CriticalHitLow.ToString();
        CriticalHighText.text = bs.CriticalHitHigh.ToString();
        goldText.text ="Gold:"+ goldScript.currentGold.ToString();
        if (logE==true)
        {
            errorText.text = logError.ToString();
        }
    }

   public void IcrementMaxValueDamage()
    {
        if (goldScript.currentGold>=35)
        {
            bs.maxValue += 1;
            bs.CriticalHitHigh += 1;
            goldScript.currentGold -= 35;
        }
        else
        {
            errorText.text = NotEnough;
        }
            
    }
    public void IncrementMinValueDamage()
    {
    if (goldScript.currentGold>=35 && bs.minValue<bs.maxValue)
    {
            bs.minValue += 1;
            bs.CriticalHitLow += 1;
            goldScript.currentGold -= 35;
        }
        if (goldScript.currentGold < 35)
        {
            errorText.text = NotEnough;
        }
        if (goldScript.currentGold>=35 &&bs.minValue==bs.maxValue)
        {
            errorText.text = logError;
        }
       
       
       
    }
    public void IncrementYourArmor()
    {
        if (goldScript.currentGold>=45)
        {
            bs.Armor += 0.2f;
            goldScript.currentGold -= 45;
        }
        else
        {
            errorText.text = NotEnough;
        }
       
    }
    public void Ok()
    {
        errorText.text = nothing;
        priceText.enabled=false;
        Time.timeScale = 0;
        unknownTime.SetActive(true);
        ps.goldImage.enabled = true;
        ps.statisticButton.SetActive(true);
        unknownTime.SetActive(true);
        panel.SetActive(false);
        
    }
   
}
