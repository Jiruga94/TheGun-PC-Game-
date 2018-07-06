using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum Res { timeCount, respawnTime, timebtwFight }
public class Counter : MonoBehaviour
{

    public float timeToappearsElite = 0;
    private float one = 1;
    public Text t;

   
    public float between = 0f;
    public float between2 = 0f;
    private GameObject go;

    public bool reset;
    private Elite elite;
    [HideInInspector]public bool contin;
    public bool EnabledSlider;
    public Respawn respawnEnum;
    private EnemyStatistic stats;
    public Res r;

    private UnknownTimer unknownTimer;
    void Start()
    {
        contin=false;
        between = 40;
        between2 = 50;
        EnabledSlider = false;
        reset = false;
        t = GetComponent<Text>() as Text;
        stats = FindObjectOfType<EnemyStatistic>();
        timeToappearsElite = Random.Range(between, between2);
        elite = FindObjectOfType<Elite>();
        unknownTimer=FindObjectOfType<UnknownTimer>();

    }

    void Update()
    {
        if(unknownTimer.stopTimeCount==false){
        Timer();
        }
     
    }
    public void Timer()
    {
       
        timeToappearsElite -= Time.deltaTime;
        
     

        t.text = "Time until elite appears:" + Mathf.Round(timeToappearsElite) + " seconds!";
        if (timeToappearsElite <= 9.5)
        {
            t.text = "Time until elite appears:" + "0" + Mathf.Round(timeToappearsElite) + " seconds!";

            if (timeToappearsElite <= 0)
            {

                t.text = "Time until elite appears:" + "00" + " seconds!";

                timeToappearsElite = 0;

               

            }
        }
        if (reset == true )
        {
            timeToappearsElite = Random.Range(40, 50);

            elite.isPresent = false;
            reset = false;


        }
    }
}
    
    

