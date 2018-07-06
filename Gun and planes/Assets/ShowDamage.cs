using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowDamage : MonoBehaviour {

    private Text damageText;
    private SecondUfoHealth ufohp;
    public Canvas can;
    private MoveTheBullet moveTheBullet;
    private BarrelStats bs;
    
	void Start () {
        damageText = GetComponent<Text>();
        ufohp = FindObjectOfType<SecondUfoHealth>();
        moveTheBullet = FindObjectOfType<MoveTheBullet>();
        bs = FindObjectOfType<BarrelStats>();
        
    }
	
	
	void Update () {

       
            damageText.text = bs.damage.ToString();
        
            
            
        
        //StartCoroutine(DamageHit());
	}
    IEnumerator DamageHit()
    {
        if (ufohp.hit == true)
        {
            
            if (ufohp.showMyDamage != 0)
            {
                Debug.Log("!!!!!");
                damageText.text = ufohp.showMyDamage.ToString();
                yield return new WaitForSeconds(3.0f);
                damageText.text = null;
            }
        }
    }
    
}
