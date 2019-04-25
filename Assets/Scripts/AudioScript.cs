using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioScript : MonoBehaviour {

	public AudioClip MusicClipWin;
	public AudioClip MusicClipLose;

	public AudioClip mainMenu;
	public AudioClip levelSelection;
	public AudioClip gamePlay;

	public AudioSource MusicSource;

	void Start(){
		if (myGameManager.isSoundActive) {
			AudioListener.volume = 1;
		} else {
			AudioListener.volume = 0;
		}

	}

	public void OnWin(){
		if (myGameManager.isSoundActive) {
			MusicSource.clip = MusicClipWin;
			MusicSource.Play ();
		}
	}

	public void OnLose(){
		if (myGameManager.isSoundActive) {
			MusicSource.clip = MusicClipLose;
			MusicSource.Play ();
		}
	}

	public void onMainMenu(){
		if (myGameManager.isSoundActive) {
			MusicSource.clip = mainMenu;
			MusicSource.Play ();
		}
	}

	public void OnLevelSelection(){
		if (myGameManager.isSoundActive) {
			Debug.Log ("Inside");
			MusicSource.clip = levelSelection;
			MusicSource.Play ();
		}
	}

	public void OnGamePlay(){
		if (myGameManager.isSoundActive) {
			MusicSource.clip = gamePlay;
			MusicSource.Play ();
		}
	}
}
