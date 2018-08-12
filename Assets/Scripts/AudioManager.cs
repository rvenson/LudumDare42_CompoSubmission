using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour {

	public static AudioManager instance;
	public Sound[] soundList;

	void Awake(){
		if(instance == null){
			instance = this;
		} else {
			Destroy(gameObject);
		}
	}

	public void PlayFX(string name, Transform audioPosition = null){
		if(audioPosition == null){
			audioPosition = this.transform;
		}
		GameObject soundObj = new GameObject(name + " sound");
		soundObj.transform.parent = gameObject.transform;
		AudioSource soundSource = soundObj.AddComponent(typeof(AudioSource)) as AudioSource;
		soundSource.loop = false;

		//make the sound 2D if has no position, position if has
		if(audioPosition == this.transform){
			soundSource.spatialBlend = 0f;
		} else {
			soundSource.spatialBlend = 1f;
			soundObj.transform.position = audioPosition.position;
		}

		//if sound is found
		Sound soundClip = SearchSound(name);
		if(soundClip != null){
			
			//If have distortion
			if(soundClip.distortion){
				soundSource.pitch = Random.Range(0.9f, 1.1f);
			}
			
			soundSource.clip = soundClip.clip;
			soundSource.Play();
		}

		//Destroy after play
		Destroy(soundObj, soundClip.clip.length);

	}

	Sound SearchSound(string clipName){
		foreach(Sound s in soundList){
			if(s.soundName == clipName){
				return s;
			}
		}

		Debug.LogWarning("Sound " + clipName + " not found!");
		return null;
	}
	
}
