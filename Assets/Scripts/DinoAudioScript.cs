using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DinoAudioScript : MonoBehaviour {
	public AudioClip DinoDeath;
	public AudioClip DinoWalk;
	public AudioClip DinoRun;
	public AudioClip DinoAttack;
	public bool audioOn = false;

	public AudioSource MusicSource;

	public void OnDeath(){
		Debug.Log ("ondeath");
		MusicSource.loop = false;
		MusicSource.clip = DinoDeath;
		MusicSource.Play ();
	}

	public void OnWalk(){
		Debug.Log ("onwalk");

		MusicSource.clip = DinoWalk;
		MusicSource.Play ();
	}

	public void OnRun(){
		Debug.Log ("onrun");

		MusicSource.clip = DinoRun;
		MusicSource.Play ();
	}

	public void OnAttack(){
		Debug.Log ("onattack");

		MusicSource.loop = false;
		MusicSource.clip = DinoAttack;
		MusicSource.Play ();
	}


	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Player") {
			audioOn = true;
		}
	}

	void OnTriggerExit(Collider col){

		if (col.gameObject.tag == "Player") {
			audioOn = false;
		}

	}
}
