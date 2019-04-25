using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;
using UnityEngine.UI;

public class AllButtonGameClicks : MonoBehaviour {
	public float pauseTime;
	public GameObject[] LevelCanvas;

	public GameObject[] fpsCanvas;
	public GameObject levelFinishCanvas;

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


	public void OnClickNext(){
//		SceneManager.LoadScene("LevelSelection");
		StartCoroutine(Loading("LevelSelection"));
	}

	public void OnClickQuit(){
//		SceneManager.LoadScene("mainScene");
		StartCoroutine(Loading("mainScene"));

	}

	public void OnClickRestart(){
		SceneManager.LoadScene("GamePlay");
	}

	public void OnClickResume(){
		Time.timeScale = pauseTime;
		AudioListener.volume = 1;
		LevelCanvas [PlayerPrefs.GetInt("CurrentLevel")].SetActive(true);

		levelFinishCanvas.transform.GetChild (2).gameObject.SetActive (false);

		fpsCanvas[PlayerPrefs.GetInt("CurrentLevel")].SetActive(true);
	}

	public void OnPausePress(){
		pauseTime = Time.timeScale;
		Time.timeScale = 0.0f;

		AudioListener.volume = 0;

		LevelCanvas [PlayerPrefs.GetInt("CurrentLevel")].SetActive(false);

		levelFinishCanvas.transform.GetChild (2).gameObject.SetActive (true);

		fpsCanvas[PlayerPrefs.GetInt("CurrentLevel")].SetActive(false);
	}
}
