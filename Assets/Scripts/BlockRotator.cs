using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockRotator : MonoBehaviour {

	void FixedUpdate(){
		transform.Rotate(0, 1, 0);
	}
}
