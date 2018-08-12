using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialManager : LevelManager {

	public GameObject enemy;
	public Transform enemyRespaw;

	void Start(){
		CanvasController.instance.startScreen.SetActive(true);
		PauseGame(true);
		CanvasController.instance.pcPanel.gameObject.SetActive(false);
		StartCoroutine(StartTutorial());
	}

	IEnumerator StartTutorial(){
		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.AddDialog("Welcome to the magical world of memory management!"
		+ "\n\nHere you will learn how to operate the blocks of data to perfectly run the programs executed by your user.");
		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.dialogImage.gameObject.SetActive(true);
		CanvasController.instance.messagePanel.AddDialog("Please, note the blocks in the Hard Disk area");
		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.dialogImage.gameObject.SetActive(false);
		CanvasController.instance.messagePanel.AddDialog("Yes, these colored blocks are the data of the stored applications. Whenever your user runs a new program, you should put your data in main memory.");
		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.AddDialog("And do not underestimate the users. They will lose their patience very fast if the program can not load. Let's try loading the first program, it needs 2 blocks ...");

		CanvasController.instance.pcPanel.gameObject.SetActive(true);
		StartCoroutine(OpenApp(appList[appIndex]));

		yield return null;
	}

	protected override void NextApp(){
		base.NextApp();
		StartCoroutine(TutorialSequence01());
	}

	IEnumerator TutorialSequence01(){
		CanvasController.instance.messagePanel.AddDialog("Awsome! Now let's put another program running ...");
		yield return new WaitForSeconds(0.3f);
		CanvasController.instance.messagePanel.AddDialog("Notice that we have only one more block available in main memory.\n\nWhat should we do? You fool, you get paid to think! Put the blocks back on HD.");

		yield return new WaitForSeconds(2f);
		StartCoroutine(TutorialSequence02());

		yield return null;
	}

	IEnumerator TutorialSequence02(){
		CanvasController.instance.messagePanel.AddDialog("For Alan Turing! A trojan has invaded the system! Be careful!!!");
		Instantiate(enemy, enemyRespaw);
		yield return null;
	}
	
}
