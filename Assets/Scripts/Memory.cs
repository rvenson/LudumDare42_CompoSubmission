using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Memory : MonoBehaviour {

	public string memoryType = "Memory";
	List<Slot> slots = new List<Slot>();

	void Awake(){
		foreach (Transform t in gameObject.transform)
		{
			if(t.tag == "Slot"){
				slots.Add(t.GetComponent<Slot>());
			}
		}
	}

	public int GetLoadedBlocks(string appName){
		int appBlocks = 0;

		foreach(Slot slot in slots){
			if(slot.blockLoaded != null && slot.blockLoaded.appName == appName){
				appBlocks++;
			}
		}
		return appBlocks;
	}

	int CalculateTotalMemory(){
		return slots.Count;
	}

	int CalculateUsedMemory(){
		int usedMemory = 0;
		foreach(Slot slot in slots){
			if(slot.blockLoaded != null){
				usedMemory++;
			}
		}
		return usedMemory;
	}
	
}
