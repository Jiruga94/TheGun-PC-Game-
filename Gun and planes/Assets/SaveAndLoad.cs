using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
public static class SaveAndLoad {

	public static void SavePlayer(BarrelStats barrel)
    {
        BinaryFormatter bf = new BinaryFormatter();
        FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav",FileMode.Create);

        PlayerDataa _data = new PlayerDataa(barrel);

        bf.Serialize(stream, _data);
        stream.Close();
    }
    public static int[] LoadPlayer()
    {
        if (File.Exists(Application.persistentDataPath + "/player.sav"))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream stream = new FileStream(Application.persistentDataPath + "/player.sav", FileMode.Open);

            PlayerDataa data = bf.Deserialize(stream) as PlayerDataa;

            stream.Close();
            return data.stats;

        }
        else
        {
            Debug.LogError("File does not exist");
            return new int[2];
        }
    }
}
[Serializable]
public class PlayerDataa
{
    public int[] stats;
    public PlayerDataa(BarrelStats barrel)
    {
        stats = new int[2];
        stats[0] = barrel.minValue;
        stats[1] = barrel.maxValue;
    }
}
