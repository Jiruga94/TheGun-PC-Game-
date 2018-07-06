using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class Elite : MonoBehaviour
{

    public delegate void CreateChosenFunction();

   
    public enum States { Random, chosen, respawn,death,diff}
   
    private float waitOneSecond = 1.0f;
    private float wait = 0f;
    public Transform[] Minions;
    public int damage;
    public Transform firstElite;
    public Transform secondElite;
    private int count = 0;
    [HideInInspector]
    public float _random = 0;
    
    private ArrayList commonMonsters;
    private ArrayList ListOf;
    private float gold = 0;
    public List<Transform> ListOfMonsters;
    public States states;
    private float w = 2.0f;
    private int timeStart = 0;
    private float seconds = 0.0f;
    private float one = 1.0f;
    public bool eliteisDeath;
    private LastBossController lastB;
    public bool rageStarted;
    private SliderControl slider;
    private float rage;
    public bool respawnMonster;
    private Counter timer;
    public GameObject sliderOn;
    public bool turnOnscripts;
    [SerializeField]
    private Transform rpoint;
    [SerializeField]
    private Transform srpoint;
    public bool isPresent;
    private int goldTime;
    public int Lowerdamage;
    public int Maxdamage;
    public const int constansValueGold = 100;
    public const int constansValueGold2 = 200;
    public const int constanceValueGold3 = 300;
    private AudioManager audioManager;
    private int salary;
    private HerculesHealth herculesHealth;
    private MoveHrc moveHrc;
    public bool g;
    [HideInInspector]
    public int Armor = 10;
  
    private int timeToRespawn;
  
    public GameObject gate;

    private static Elite elite;
    public Res r;
    public bool respawn;
    public bool OpenG;
    public bool darkness;
    #region pokolei
    /*
    -najpierw funkcja losujaca elite
    - po wylosowaniu przydziel jej wartosc zycia oraz czas rage()
     - nastepnie ma rzydzielic ilosc podstawowych przeciwnikow
     -funkcja ktora przydziela ilosc golda(iloscZyciaPotwora*iloscZyciaGracza/czasWktorymPokonalismyPotwora)
     -
           */
    #endregion


    private void Awake()
    {
        /*if (elite == null)
        {
            DontDestroyOnLoad(gameObject);
            elite = this;
        }
        else if (elite != this)
        {
            Destroy(gameObject);
        }*/
    }
    void Start()
    {
        _random = 0;
        darkness = false;
        audioManager = AudioManager.instance;
        g = false;
        gate.SetActive(false);               
        isPresent = false;
        moveHrc = FindObjectOfType<MoveHrc>();
        turnOnscripts = false;
        eliteisDeath = false;
        lastB = FindObjectOfType<LastBossController>();
        slider = FindObjectOfType<SliderControl>();
        rageStarted = false;
        respawnMonster = false;
        rage = Random.Range(40, 50);
        timer = FindObjectOfType<Counter>();
       
        herculesHealth = FindObjectOfType<HerculesHealth>();
        _random = Random.Range(1, 2);
      
    }


   
    public void ChooseTheMonster()
    {
        //Here i random between 3 elites , script chose number and based on number elite will have chosen
        

        Debug.Log(_random + " Wylosowany numer");
       
        states = States.chosen;

        if (_random == 1)
            {
            
                states = States.respawn;           
                isPresent = false;
                 g = true;
                salary = constansValueGold;
                count = 1;
                Debug.Log("Potwor " + firstElite.name);          
                Instantiate(firstElite, rpoint.transform.position, rpoint.transform.rotation);               
                isPresent = true;
                r = Res.timebtwFight;
       
             }
            if (_random == 2)
            {
            isPresent = false;
            salary = constansValueGold2;
            count = 1;
            Debug.Log("Potwor " + secondElite.name);           
                Instantiate(secondElite, srpoint.transform.position, srpoint.transform.rotation);
            isPresent = true;
            r = Res.timebtwFight;
 
        }      
    }

    private void Update()
    {
        
        GoldForKillEnemy();
        damage = Random.Range(Lowerdamage, Maxdamage);
        if (timer.timeToappearsElite<=0 && isPresent==false )
        {                      
           
            if (_random == 1) {
                StartCoroutine(OpenGate());
                if (respawn==true)
                {
                    ChooseTheMonster();                  
                    StartCoroutine(CloseGate());                   
                }          
            }
            if (_random == 2) { ChooseTheMonster();}
        }
    }

  
  public void GoldForKillEnemy()
    {

        if (isPresent==true)
        {
          
            if (timer.reset==true)
            {
                Debug.Log(Mathf.Round(gold) + " my gold");
            }
            
        }
    }

   
    public IEnumerator OpenGate()
    {
        darkness = true;
        audioManager.PlaySound("SpaceGate");
        gate.SetActive(true);
       
        yield return new WaitForSeconds(4.0f);
        respawn = true;
     

    }
    public IEnumerator CloseGate()
    {

        yield return new WaitForSeconds(4.0f);

        respawn = false;
        gate.SetActive(false);
        audioManager.StopSound("SpaceGate");
    }
}






public class ElitesController : MonoBehaviour
    {


        #region Co i jak z tym skryptem
        /*
          -nazwa elity 
          -ilosc zycia
          -
          -program losowo wybiera z listy ktorego wstawic pod koniec gry
          -czy moze sie leczyc 
          -RAGE!!!!        
          -czas odliczajacy rage
          -napisz funkcje ktora bedzie leczyc elite
          -ma wybierac losowa ilosc oraz losowy rodzaj zwyklych pomagierow
        -kazda elita ma miec specyficzna dla siebie funkcje np odbijanie strzalow
        -losowa ilosc golda za pokonanie elity (miedzy dwiema stalymi wartosciami)
        -napisz osobne funkcje ktore beda dzialac podczas rage*/


        #endregion
    }





