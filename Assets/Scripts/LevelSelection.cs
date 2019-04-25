using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class LevelSelection : MonoBehaviour {
	public List<Sprite> mapImages;
	public Image activeMapImage;
	public GameObject canvas;
	public Text missionStatement;
	public Text gunChange;
	public Button hunt;
	public GameObject backBtn;

	int level;

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

	void OnStart(){
		Time.timeScale = 1;

		hunt.interactable = false;
	}

	public void OnLevelClick(int i){

		int unlockLevel = PlayerPrefs.GetInt ("activeLevels");//1

		if (unlockLevel >= (i - 1)) {

//			iTween.ScaleTo (hunt.gameObject, iTween.Hash ("x", 1.5f, "y", 1.5f, "time", 0.5f, "easetype", iTween.EaseType.easeOutElastic));

			hunt.interactable = true;

		} else {
			hunt.interactable = false;
//			iTween.ScaleTo (hunt.gameObject, iTween.Hash ("x", 0f, "y", 0f, "time", 0.2f, "easetype", iTween.EaseType.linear));

		}

//		if (PlayerPrefs.GetInt ("level" + i + "Unlock") != 0) {
//			hunt.interactable = true;
//		} else {
//			hunt.interactable = false;
//		}
		level = i - 1;
		if (i % 4 == 0) {
			activeMapImage.GetComponent<Image> ().sprite = mapImages [3];
		} else if (i % 4 == 1) {
			activeMapImage.GetComponent<Image> ().sprite = mapImages [0];
		} else if (i % 4 == 2) {
			activeMapImage.GetComponent<Image> ().sprite = mapImages [1];
		} else if (i % 4 == 3) {
			activeMapImage.GetComponent<Image> ().sprite = mapImages [2];
		}

		//mission statements
		if (i == 1) {
			missionStatement.text = "Find And Kill Two Stegosaurus.";
		} else if (i == 2) {
			missionStatement.text = "Find And Kill One Parasaurolophus And One Ankylosaurus.";
		} else if (i == 3) {
			missionStatement.text = "Find And Kill One Carnotaurus And Two Velociraptor.";
		} else if (i == 4) {
			missionStatement.text = "Kill One Ankylosaurus With A Heart Shot And A Carnotaurus With Lung Shot.";
		} else if (i == 5) {
			missionStatement.text = "Find And Kill Two Stegosaurus And One Triceratops Using NightVision.";
		} else if (i == 6) {
			missionStatement.text = "Kill Two Tyrannosaurus And A Spinosaurus With Heart Shot.";
		} else if (i == 7) {
			missionStatement.text = "Find And Kill Two Velociraptor And One Carnotaurus Using NightVision.";
		} else if (i == 8) {
			missionStatement.text = "Kill One Ankylosaurus With A Heart Shot A Carnotaurus With Lung Shot And Two Spinosaurus.";
		} else if (i == 9) {
			missionStatement.text = "Find And Kill Two Tyrannosaurus And Three Spinosaurus.";
		} else if (i == 10) {
			missionStatement.text = "Find And Kill Two Brontosaurus And Two Stegosaurus.";
		} else if (i == 11) {
			missionStatement.text = "Find And Kill Three Stegosaurus And Three Parasaurolophus.";
		} else if (i == 12) {
			missionStatement.text = "Kill One Triceratops With Heart Shot One Tyrannosaurus with Lung Shot And Two Brontosaurus.";
		} else if (i == 13) {
			missionStatement.text = "Find And Kill Three Ankylosaurus And Three Velociraptor.";
		} else if (i == 14) {
			missionStatement.text = "Find And Kill Three Triceratops One Stegosaurus And Two Parasaurolophus.";
		} else if (i == 15) {
			missionStatement.text = "Find And Kill Three Stegosaurus And Three Parasaurolophus.";
		} else if (i == 16) {
			missionStatement.text = "Kill One Parasaurolophus With Heart Shot One Ankylosaurus with Lung Shot And Two Tyrannosaurus.";
		}
	}

	public void OnClickWeaponShop(){
		
	}

	public void GunSelection(){
		
		canvas.transform.GetChild (1).gameObject.SetActive (true);
		canvas.transform.GetChild (0).gameObject.SetActive (false);
		PlayerPrefs.SetInt ("CurrentLevel", level);

	}

	public void onClickBack(){
		canvas.transform.GetChild (1).gameObject.SetActive (false);
		canvas.transform.GetChild (0).gameObject.SetActive (true);
	}

	public void MissionStatment(){
		if (PlayerPrefs.GetInt ("CurrentLevel") == 4 || PlayerPrefs.GetInt ("CurrentLevel") == 6 || PlayerPrefs.GetInt ("CurrentLevel") == 8 || PlayerPrefs.GetInt ("CurrentLevel") == 12 || PlayerPrefs.GetInt ("CurrentLevel") == 16) {
			if (PlayerPrefs.GetInt ("CurrentGun") == 1) {
				gunChange.text = "YOU NEED A GUN WITH INFRARED CAPABILITY.";
				return;
			}
		}

			canvas.transform.GetChild (1).gameObject.SetActive (false);
			canvas.transform.GetChild (2).gameObject.SetActive (true);

	}

	public void PlayLevel (){
//		SceneManager.LoadScene ("GamePlay");
		StartCoroutine(Loading("GamePlay"));
	}

	public void onClickMainMenu(){
		SceneManager.LoadScene ("mainScene");
	}

//	public void purchase_M4A1Gun(){
//		GSF_InAppController.Instance.BuyInAppProduct (1);
//	}
//
//	public void purchase_SVDGun(){
//		GSF_InAppController.Instance.BuyInAppProduct (2);
//	}
//
//	public void purchase_SniperGun(){
//		GSF_InAppController.Instance.BuyInAppProduct (3);
//	}
//
//	public void purchase_SniperAWPGun(){
//		GSF_InAppController.Instance.BuyInAppProduct (4);
//	}
//
//	public void unlockAllGuns(){
//		GSF_InAppController.Instance.BuyInAppProduct (5);
//	}
}
