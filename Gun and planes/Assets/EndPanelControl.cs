using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndPanelControl : MonoBehaviour {

public GameObject myPanel;
private Counter counter;

private Elite elite;


private UnknownTimer unknownTimer;
void Start()
{
	elite=FindObjectOfType<Elite>();
	counter=FindObjectOfType<Counter>();
	unknownTimer=FindObjectOfType<UnknownTimer>();
	
}
[SerializeField] private GameObject[] gameObj;
	
		
	public void Close(){
		for (int i = 0; i < gameObj.Length; i++)
		{
			gameObj[i].SetActive(true);
		}
		
		myPanel.SetActive(false);
		unknownTimer.stopTimeCount=false;
		
		
	}

}
