using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour {

	public Memory ram;
	public Application[] appList;
	Application foregroundApp = null;
	bool gamePause = false;
	int appIndex = 0;

	void Start(){
		OpenApp(appList[appIndex]);
	}

	void OpenApp(Application app){
		foregroundApp = app;
		gamePause = false;
	}

	void FixedUpdate(){
		ProcessApp();
	}

	void ProcessApp(){
		if(foregroundApp != null && !gamePause){
			
			Debug.Log("usetime: " + foregroundApp.useTime + " / waitTime: " + foregroundApp.waitTime + " / Blocks: " + ram.GetLoadedBlocks(foregroundApp.appName));
			
			if(ram.GetLoadedBlocks(foregroundApp.appName) >= foregroundApp.size){
				foregroundApp.useTime -= Time.fixedDeltaTime;
			} else {
				foregroundApp.waitTime -= Time.fixedDeltaTime;
			}

			if(foregroundApp.waitTime < 0){
				LossCondition();
			} else if (foregroundApp.useTime < 0){
				NextApp();
			}
		}
	}

	void NextApp(){
		Debug.Log("next");
		gamePause = true;
		appIndex++;
		if(appIndex < appList.Length){
			OpenApp(appList[appIndex]);
		} else {
			WinCondition();
		}
	}

	void LossCondition(){
		Debug.Log("Voce perdeu");
		gamePause = true;
	}

	void WinCondition(){
		Debug.Log("Você ganhou");
		gamePause = true;
	}

}
