using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndSceneController : LevelManager {

	public bool end = false;

	void Start(){
		PauseGame(false);
		StartCoroutine(EndSceneSequence());	
	}

	void Update(){
		if(end && Input.GetButtonDown("Jump")){
			MainMenu();	
		}
	}	

	IEnumerator EndSceneSequence(){

		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.AddDialog("You have surpassed all expectations and... come on, you just did your job ...");

		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.AddDialog("At the end of the day, your user just shut down the computer and left you alone, after all, not all stories end up happy. You will remain disabled until you have a new opportunity to showcase your talents.");

		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.AddDialog("\"If a machine is expected to be infallible, it cannot also be intelligent.\"\n― <i>Alan Turing</i>\n\nThanks for playing! (@rvenson)");

		end = true;

		yield return null;
	}
	
}
