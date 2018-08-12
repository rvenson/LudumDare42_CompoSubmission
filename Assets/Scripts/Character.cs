using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

	public string charName = "Default Firmware";
	public float maxLife = 10;
	public float life = 10;

	public void Damage(float amount){
		life -= amount;

		if(life <= 0){
			Death();
		}
	}

	public virtual void Death(){
		Destroy(gameObject);
	}
	
}
