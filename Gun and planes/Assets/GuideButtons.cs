using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GuideButtons : MonoBehaviour {

	public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void EnemiesScene()
    {
        SceneManager.LoadScene(4);
    }
    public void BarrelPage()
    {
        SceneManager.LoadScene(5);
    }
    public void Back()
    {
        SceneManager.LoadScene(3);
    }
	
}
