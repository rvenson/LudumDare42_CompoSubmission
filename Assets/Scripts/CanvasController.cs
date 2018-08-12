using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasController : MonoBehaviour {

	public static CanvasController instance;
	public PCPanelUI pcPanel;
	public MessagePanelUI messagePanel;
	public GameObject lossScreen;
	public GameObject winScreen;
	public GameObject startScreen;
	public GameObject pausePanel;

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	void Start(){
		pcPanel.gameObject.SetActive(false);
	}

	public void EndLevel(bool win){
		
		messagePanel.gameObject.SetActive(false);
		pcPanel.gameObject.SetActive(false);
		
		if(win){
			winScreen.SetActive(true);
		} else {
			lossScreen.SetActive(true);
		}
	}

	public void StartLevel(){
		startScreen.SetActive(false);
		pcPanel.gameObject.SetActive(true);
	}
	
}
