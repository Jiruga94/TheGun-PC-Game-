using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.SceneManagement;


public class GameCotroller : MonoBehaviour
{
    private BarrelStats barrelStats;
    public static GameCotroller scoreControl;
    private ScoreManager scoreManager;
    public float score;
    public int Mindamage = 0;
    public int Maxdamage = 0;

    
     void Start()
    {


        // audioSource.SetActive(false);
            barrelStats = FindObjectOfType<BarrelStats>();
            scoreManager = FindObjectOfType<ScoreManager>();
            scoreManager.highScoreText.text = "Highscore: " + scoreManager.highScoreCount;


        Mindamage = barrelStats.minValue;
        Maxdamage = barrelStats.maxValue;
        
        
    }
    void Awake()
    {
        if (scoreControl == null)
        {
            DontDestroyOnLoad(gameObject);
            scoreControl = this;
        }
        else if (scoreControl != this)
        {
            Destroy(gameObject);
        }
    }
    void Update()
    {
       
            score = scoreManager.highScoreCount;
        if (score>scoreManager.highScoreCount)
        {
            Save();
        }
    }
    void OnGUI()
    {
            GUI.Label(new Rect(1000, 1000, 100, 300), "Highscore: " + scoreManager.highScoreCount);
        GUI.Label(new Rect(1000, 1000, 100, 300), "DamageMinValue: " + barrelStats.minValue + "DamageMaxValue: " + barrelStats.maxValue);       
    }
    public void Save()
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");
        PlayerData data = new PlayerData();
        data.Highscore = score;        
        bf.Serialize(file, data);
        file.Close();
    }
    public void SaveDamage()
    {
        BinaryFormatter bfr = new BinaryFormatter();
        FileStream secondfile = File.Create(Application.persistentDataPath + "/playerInfo2.dat");
        PlayerData data = new PlayerData();
        data.lowDamage = Mindamage;
        data.highDamage = Maxdamage;
        bfr.Serialize(secondfile, data);
        secondfile.Close();
    }
    public void Load()
    {
        if (File.Exists(Application.persistentDataPath+"/playerInfo.dat"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Open(Application.persistentDataPath+ "/playerInfo.dat",FileMode.Open);
            PlayerData data = (PlayerData)bf.Deserialize(file);
            file.Close();
            score = data.Highscore;
        }
    }
    public void LoadDamage()
    {
        if (File.Exists(Application.persistentDataPath + "/playerInfo2.dat"))
        {
            BinaryFormatter bfr = new BinaryFormatter();
            FileStream secondfile = File.Open(Application.persistentDataPath + "/playerInfo2.dat", FileMode.Open);
            PlayerData data = (PlayerData)bfr.Deserialize(secondfile);
            secondfile.Close();
            data.lowDamage = Mindamage;
            data.highDamage = Maxdamage;
          
        }
    }
}
[System.Serializable]
class PlayerData
{
    public float Highscore;
    public int lowDamage;
    public int highDamage;
}
