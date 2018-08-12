using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	void Update () {
		if(PlayerController.instance.gameObject != null){
			Vector3 offset = new Vector3(0, 6, -10);
			gameObject.transform.position = PlayerController.instance.gameObject.transform.position + offset;
		}
	}
}
