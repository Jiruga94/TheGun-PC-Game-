using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowCritWord : MonoBehaviour {

    public Text myCriticalText;
    public Canvas myCanvas;
    public Transform pointToRespawn;
    private BarrelStats bs;
	void Start () {
        bs = FindObjectOfType<BarrelStats>();
        //android 97 font size
       
    }		
	void Update () {
        if (bs.criticalHit==true)
        {
            Text t = Instantiate(myCriticalText, pointToRespawn.transform.position, pointToRespawn.transform.rotation) as Text;
            t.transform.SetParent(myCanvas.transform, false);
            t.fontSize = 10;
            Destroy(t.gameObject, 3.0f);
            bs.criticalHit = false;
        }
    }
}
