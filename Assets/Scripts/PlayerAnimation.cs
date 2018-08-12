using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

	public GameObject rightArm;
	public GameObject leftArm;

	public void Up(){
		rightArm.transform.Rotate(180, 0, 0);
		leftArm.transform.Rotate(180, 0, 0);
	}

	public void Down(){
		rightArm.transform.Rotate(-180, 0, 0);
		leftArm.transform.Rotate(-180, 0, 0);
	}
	
}
