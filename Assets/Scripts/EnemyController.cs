using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {

	NavMeshAgent _nav;
	public Transform target;

	void Awake(){
		_nav = GetComponent<NavMeshAgent>();
	}

	void FixedUpdate(){
		if(target != null){
			_nav.SetDestination(target.position);
		}
	}

	void OnTriggerEnter(Collider other){
		Debug.Log("enter");
		if(other.CompareTag("Player")){
			other.GetComponentInParent<Character>().Damage(3);
		}
	}

	
}
