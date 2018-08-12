using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public static CanvasController instance;
	public PCPanelUI pcPanel;
	public GameObject lossScreen;
	public GameObject winScreen;
	public GameObject startScreen;

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void EndLevel(bool win){
		if(win){
			winScreen.SetActive(true);
		} else {
			lossScreen.SetActive(true);
		}
	}
	
}
