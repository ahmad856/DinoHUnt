using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class mainSceneScript : MonoBehaviour {
	public GameObject canvas;
	public bool canvasBool = false;
	public Text coins;
	public Toggle soundButton;
	public Image sound;
	public Sprite on;
	public Sprite off;
	public AudioSource MusicSource;

	public static mainSceneScript Instance;


	AsyncOperation asyncLevelLoad;
	public GameObject LoadingFiller;
	public GameObject LoadingDailog;

	void FixedUpdate()
	{
		try
		{ 
			if(asyncLevelLoad != null)
				LoadingFiller.GetComponent<Image>().fillAmount = asyncLevelLoad.progress;
		}

		catch (NullReferenceException ex)
		{
			Debug.Log("Async not loaded!");
		}
	}


	IEnumerator Loading(string LevelName) 
	{
		LoadingDailog.gameObject.SetActive (true);
		asyncLevelLoad = SceneManager.LoadSceneAsync (LevelName);
		yield return asyncLevelLoad;
	}

	void Awake(){
		if (PlayerPrefs.HasKey ("Coins"))
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		else
			coins.text = "0";
	}

	void Start(){
		
		if (myGameManager.isSoundActive) {
			AudioListener.volume = 1;
		} else {
			AudioListener.volume = 0;
		}
	}

	public void playButton(){

		StartCoroutine (Loading ("LevelSelection"));

//		SceneManager.LoadScene("LevelSelection");
	}

	public void SettingOnSelect(){
		canvas.transform.GetChild (2).gameObject.SetActive (true);
	}

	public void OnSettingBack(){
		canvas.transform.GetChild (2).gameObject.SetActive (false);
	}

	public void OnStarterPack(){
		
	}

	public void onBonus(){
		if (!canvasBool) {
			canvas.transform.GetChild (1).gameObject.SetActive (true);
			canvasBool = true;
		} else {
			canvas.transform.GetChild (1).gameObject.SetActive (false);
			canvasBool = false;
		}
	}

	public void OnFeatureSelect(){
		
	}

//	public void noAds(){ //Remove Ads button
//		GSF_InAppController.Instance.BuyInAppProduct (0);
//	}

	public void OnSound(){
//		this.gameObject.GetComponent<AudioScript> ().onMainMenu ();
		if (soundButton.isOn) {
			myGameManager.isSoundActive = true;
			sound.sprite = on;
			AudioListener.volume = 1;
		} else {
			myGameManager.isSoundActive = false;
			sound.sprite = off;
			AudioListener.volume = 0;
		}
	}
}
