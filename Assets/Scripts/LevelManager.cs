using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public static LevelManager instance;
	public string levelName = "Level00";
	public string nextLevelName = "Level00";

	public Memory ram;
	public ApplicationModel[] appList;
	ApplicationModel foregroundApp = null;
	bool gamePause = false;
	bool gameStarted = false;
	public bool gameFinished = false;
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
		StartCoroutine(OpenApp(appList[appIndex]));
		PauseGame(true);
	}

	IEnumerator OpenApp(ApplicationModel app, float delay = 0){
		CanvasController.instance.messagePanel.AddMessage("Loading " + app.appName 
		+ "(" + app.size + " Blocks)", true);
		yield return new WaitForSeconds(delay);
		foregroundApp = app;
		gamePause = false;
		CanvasController.instance.pcPanel.SetMainMemory(ram);
		CanvasController.instance.pcPanel.SetActualApplication(foregroundApp);

		yield return null;
	}

	void FixedUpdate(){
		ProcessApp();
	}

	void Update(){
		if(!gameStarted && Input.GetButtonDown("Jump")){
			CanvasController.instance.StartLevel();
			PauseGame(false);
			gameStarted = true;
		}

		if(Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Escape)){
			CanvasController.instance.pausePanel.SetActive(!gamePause);
			PauseGame(!gamePause);
		}
	}

	public void PauseGame(bool pause){
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
			StartCoroutine(OpenApp(appList[appIndex], 3f));
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

	public void NextLevel(){
		SceneManager.LoadScene(nextLevelName);
	}

	public void RestartLevel(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void MainMenu(){
		SceneManager.LoadScene("MainMenu");
	}

}
