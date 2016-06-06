using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour {

	public AudioSource pawnPlacementSource;
	public AudioSource smashSoundSource;
	
	private static SoundManager instance;
	
	public static SoundManager GetInstance () {
		return instance;
	}

	// Use this for initialization
	void Awake () {
		if (instance != null) {
			this.enabled = false;
		} else {
			instance = this;
		}
	}
	
	public void PlayPawnPlacementSound () {
		pawnPlacementSource.Play();
	}

	public void PlaySmashSound () {
		smashSoundSource.Play();
	}
}
