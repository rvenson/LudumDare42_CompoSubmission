using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueController : MonoBehaviour {

	public float delay = 4f;
	bool isRelease = false;
	public bool nextLevel = false;

	void Start(){
		StartCoroutine(ReleaseContinueButton(delay));
	}

	IEnumerator ReleaseContinueButton(float delay = 0f){
		Debug.Log("rel");
		yield return new WaitForSecondsRealtime(delay);
		isRelease = true;
		Debug.Log("ease");
	}

	void Update(){
		if(isRelease && Input.GetButtonDown("Jump")){
			if(nextLevel){
				LevelManager.instance.NextLevel();
			} else {
				LevelManager.instance.RestartLevel();
			}
		}
	}
	
}
