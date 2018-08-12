using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public static PlayerController instance;
	public PlayerCharacter character;

	public Transform holder;
	float speed = 0.1f;
	GameObject actualTrigger = null;
	Block holdBlock = null;
	Vector3 movement = new Vector3(0, 0, 0);

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(gameObject);
		}

		character = GetComponent<PlayerCharacter>();
	}

	void Update () {
		UpdateMovement();
		Action();
	}

	void FixedUpdate(){
		Movement();
	}

	void UpdateMovement(){
		float hAxis = Input.GetAxis("Horizontal");
		float vAxis = Input.GetAxis("Vertical");
		movement = new Vector3(hAxis, 0, vAxis).normalized * speed;
	}

	void Movement(){
		gameObject.transform.position += movement;
	}

	void Action(){
		if(Input.GetButtonDown("Jump")){
			//If is a valid slot tag, check if is free or not
			if(actualTrigger != null && actualTrigger.tag == "Slot"){
				if(holdBlock == null){
					Slot slot = actualTrigger.GetComponent<Slot>();
					if(slot.blockLoaded != null){
						slot.blockLoaded.transform.SetParent(holder);
						slot.blockLoaded.transform.localPosition = new Vector3(0, 0, 0);
						holdBlock = slot.blockLoaded;
						slot.blockLoaded = null;
					}
				} else {
					Slot slot = actualTrigger.GetComponent<Slot>();
					if(slot.blockLoaded == null){
						holdBlock.transform.SetParent(actualTrigger.transform);
						holdBlock.transform.localPosition = new Vector3(0, 1.4f, 0);
						slot.blockLoaded = holdBlock;
						holdBlock = null;
					}
				}
			}
		}
	}

	void OnTriggerEnter(Collider other){
		actualTrigger = other.gameObject;
	}

	void OnTriggerExit(){
		actualTrigger = null;
	}
}
