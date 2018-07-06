using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScript : MonoBehaviour
{    
    [HideInInspector]
    public string Apache = "Apaches";
    [HideInInspector]
    public string SmallPlanes = "Small plane";
    [HideInInspector]
    public string SmallUfo = "Small ufo";
    [HideInInspector]
    public string SpaceShuttle = "Space shuttle";
    [HideInInspector]
    public string Elite = "Elite";
    [HideInInspector]
    public string Hercules = "Hercules";
    [HideInInspector]
    public int amountOfApaches;
    [HideInInspector]
    public int amountOfSmallPlanes;
    [HideInInspector]
    public int amountOfSmallUfo;
    [HideInInspector]
    public int amountOfSpaceShuttle;
    [HideInInspector]
    public int amountOfElite;
    [HideInInspector]
    public int amountOfHercules;
    [HideInInspector]
    public int amountOfRocket;
    public Dictionary<string, int> myContent = new Dictionary<string, int>();
  

    private void Start()
    {
        amountOfApaches = 0;
        amountOfElite = 0;
        amountOfHercules = 0;
        amountOfSmallPlanes = 0;
        amountOfSmallUfo = 0;
        amountOfSpaceShuttle = 0;
        myContent.Add(Apache, amountOfApaches);
        myContent.Add(SmallPlanes, amountOfSmallPlanes);
        myContent.Add(SmallUfo, amountOfSmallUfo);
        myContent.Add(SpaceShuttle, amountOfSpaceShuttle);
        myContent.Add(Elite, amountOfElite);
        myContent[Hercules] = amountOfHercules;

    }
    private void Update()
    {
        ContentOfDestroyedPlanes();
    }
    public void ContentOfDestroyedPlanes()
    {
      amountOfApaches= myContent[Apache];
      amountOfSmallPlanes= myContent[SmallPlanes];
      amountOfElite= myContent[Elite];
      amountOfSpaceShuttle=myContent[SpaceShuttle];
       amountOfHercules= myContent[Hercules];
       amountOfSmallUfo= myContent[SmallUfo];
    }
}