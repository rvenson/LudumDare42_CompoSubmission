using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PCPanelUI : MonoBehaviour {

	public Text actualApplicationName;
	public Text actualLoadedBlocks;
	public Text actualColorName;
	
	public Image actualApplicationScreen;
	public Sprite loadScreenSprite;

	public Slider actualWaitSlider;
	public Slider actualUseSlider;
	public Slider playerLifeSlider;

	Application actualApplication;
	Memory mainMemory;

	public void Start(){
		if(PlayerController.instance != null){
			playerLifeSlider.maxValue = PlayerController.instance.character.maxLife;
		}
	}

	public void SetActualApplication(Application app){

		actualApplication = app;

		//setLoadScreen
		actualApplicationScreen.GetComponent<Image>().sprite = loadScreenSprite;

		actualApplicationName.text = app.appName;
		actualLoadedBlocks.text = mainMemory.GetLoadedBlocks(app.appName) + " / " + app.size;
		actualColorName.text = app.colorName;
		actualColorName.color = app.color;

		actualWaitSlider.maxValue = app.maxWaitTime;
		actualUseSlider.maxValue = app.maxUseTime;
	}

	public void SetMainMemory(Memory ram){
		mainMemory = ram;
	}

	void Update(){
		if(actualApplication != null){

			int loadedBlocks = mainMemory.GetLoadedBlocks(actualApplication.appName);
			int appSize = actualApplication.size;
			bool appLoaded = loadedBlocks >= appSize ? true : false;

			actualWaitSlider.value = actualApplication.waitTime;
			actualUseSlider.value = actualApplication.useTime;
			actualLoadedBlocks.text = loadedBlocks + " / " + appSize;

			 //if all blocks loaded
			 if(appLoaded){
				 actualApplicationScreen.GetComponent<Image>().sprite = actualApplication.imageScreen;
			 } else {
				 actualApplicationScreen.GetComponent<Image>().sprite = loadScreenSprite;
			 }
		}

		if(PlayerController.instance != null){
			playerLifeSlider.value = PlayerController.instance.character.life;
		}
	}
	
}
