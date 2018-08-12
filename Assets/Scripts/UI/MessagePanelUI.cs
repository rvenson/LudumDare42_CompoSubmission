using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MessagePanelUI : MonoBehaviour {

	public GameObject messageBar;
	public Text messageText;
	bool inUse = false;
	Queue<string> messageQueue = new Queue<string>();

	void Start(){
		messageBar.SetActive(false);
		messageText.text = "";
	}

	public void AddMessage(string message, bool showNow){
		messageQueue.Enqueue(message);
		if(showNow){
			ShowMessage();
		}
	}

	public void ShowMessage(){
		if(!inUse){
			inUse = true;
			messageText.text = messageQueue.Dequeue();
			messageBar.SetActive(true);
			StartCoroutine(CloseBar(3f));
		}
	}

	IEnumerator CloseBar(float wait){
		yield return new WaitForSeconds(wait);
		messageBar.SetActive(false);
		if(messageQueue.Count > 0){
			ShowMessage();
		} else {
			inUse = false;
		}
	}	
}
