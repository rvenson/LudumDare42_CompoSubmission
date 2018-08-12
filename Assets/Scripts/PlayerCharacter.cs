using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCharacter : Character {

	public override void Death(){
		LevelManager.instance.LossCondition();
	}
}
