using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GoldScript : MonoBehaviour {

    private Text GoldText;
    [HideInInspector]
    public int currentGold;
    public int totalGold;
	void Start () {
        GoldText = GetComponent<Text>();
        currentGold = 0;
        totalGold = 0;
	}
	void Update () {
        GoldText.text = currentGold.ToString();
        if (currentGold<=0)
        {
            currentGold = 0;
        }
	}

    public void GoldSalary(int _amountOfGold)
    {
        currentGold += _amountOfGold;
    }
    public void TotalGoldSalary(int _gold)
    {
        totalGold += _gold;
    }
}
