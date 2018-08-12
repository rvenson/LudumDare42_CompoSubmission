using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {

	public GameObject[] enemies;
	public Transform spawnPosition;
	public float delay = 40f;

	void Start(){
		StartCoroutine(Spawner());
	}

	IEnumerator Spawner(){
		while(!LevelManager.instance.gameFinished){
			yield return new WaitForSeconds(Random.Range(delay, delay+10f));
			Instantiate(enemies[Random.Range(0, enemies.Length - 1)], spawnPosition.position, new Quaternion());
		}
	}
	
}
