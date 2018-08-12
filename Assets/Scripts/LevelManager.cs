using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;

	public Memory ram;
	public Application[] appList;
	Application foregroundApp = null;
	bool gamePause = false;
	bool gameStarted = false;
	bool gameFinished = false;
	int appIndex = 0;

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	void Start(){
		CanvasController.instance.startScreen.SetActive(true);
		OpenApp(appList[appIndex]);
		PauseGame(true);
	}

	void OpenApp(Application app){
		foregroundApp = app;
		gamePause = false;
		CanvasController.instance.pcPanel.SetMainMemory(ram);
		CanvasController.instance.pcPanel.SetActualApplication(foregroundApp);
	}

	void FixedUpdate(){
		ProcessApp();
	}

	void Update(){
		if(!gameStarted && Input.GetButtonDown("Jump")){
			CanvasController.instance.startScreen.SetActive(false);
			PauseGame(false);
			gameStarted = true;
		}

		if(gameFinished && Input.GetButtonDown("Jump")){
			RestartLevel();
		}
	}

	void PauseGame(bool pause){
		gamePause = pause;
		if(pause){
			Time.timeScale = 0;
		} else {
			Time.timeScale = 1;
		}
	}

	void ProcessApp(){
		if(foregroundApp != null && !gamePause){
			
			//Debug.Log("usetime: " + foregroundApp.useTime + " / waitTime: " + foregroundApp.waitTime + " / Blocks: " + ram.GetLoadedBlocks(foregroundApp.appName));
			
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

	public void LossCondition(){
		Debug.Log("Voce perdeu");
		PauseGame(true);
		CanvasController.instance.EndLevel(false);
		gameFinished = true;
	}

	public void WinCondition(){
		Debug.Log("Você ganhou");
		PauseGame(true);
		CanvasController.instance.EndLevel(true);
		gameFinished = true;
	}

	public void RestartLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

}
