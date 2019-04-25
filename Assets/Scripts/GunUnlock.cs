using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GunUnlock : MonoBehaviour {
	public Text coins;
	public Button M4A1;
	public Button SVD;
	public Button Sniper;
	public Button SniperAWp;
	public Button unlockAllGuns;

	public Text lessCoin;

	public void OnUnlock(int i){
		int currentCoins = PlayerPrefs.GetInt ("Coins");
		if (i == 2) {
			//coins 2500
			if (currentCoins < 2500) {
				lessCoin.text = "YOU DON'T HAVE ENOUGH COINS.";
				unlockAllGuns.gameObject.SetActive(true);
				return;
			}
			PlayerPrefs.SetInt ("lockButton " + (i - 1), 1);
			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - 2500));
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();

		} else if (i == 3) {
			//coins 5000
			if (currentCoins < 5000) {
				unlockAllGuns.gameObject.SetActive(true);
				lessCoin.text = "YOU DON'T HAVE ENOUGH COINS.";
				return;
			}
			PlayerPrefs.SetInt ("lockButton " + (i - 1), 1);

			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - 5000));
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		} else if (i == 4) {
			//coins 10000
			if (currentCoins < 10000) {
				SniperAWp.gameObject.SetActive (false);
				Sniper.gameObject.SetActive (false);
				SVD.gameObject.SetActive (false);
				M4A1.gameObject.SetActive (true);
				lessCoin.text = "YOU DON'T HAVE ENOUGH COINS.";
				return;
			}
			PlayerPrefs.SetInt ("lockButton " + (i - 1), 1);

			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - 10000));
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		} else if (i == 5) {
			//coins 20000
			if (currentCoins < 20000) {
				SniperAWp.gameObject.SetActive (false);
				Sniper.gameObject.SetActive (false);
				SVD.gameObject.SetActive (true);
				M4A1.gameObject.SetActive (false);
				lessCoin.text = "YOU DON'T HAVE ENOUGH COINS.";

				return;
			}
			PlayerPrefs.SetInt ("lockButton " + (i - 1), 1);

			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - 20000));
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		} else if (i == 6) {
			//coins 50000
			if (currentCoins < 50000) {
				SniperAWp.gameObject.SetActive (false);
				Sniper.gameObject.SetActive (true);
				SVD.gameObject.SetActive (false);
				M4A1.gameObject.SetActive (false);
				lessCoin.text = "YOU DON'T HAVE ENOUGH COINS.";
				return;
			}
			PlayerPrefs.SetInt ("lockButton " + (i - 1), 1);

			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - 50000));
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		} else if (i == 7) {
			//coins 70000
			if (currentCoins < 70000) {
				SniperAWp.gameObject.SetActive (true);
				Sniper.gameObject.SetActive (false);
				SVD.gameObject.SetActive (false);
				M4A1.gameObject.SetActive (false);
				lessCoin.text = "YOU DON'T HAVE ENOUGH COINS.";
				return;
			}
			PlayerPrefs.SetInt ("lockButton " + (i - 1), 1);

			PlayerPrefs.SetInt ("Coins", (PlayerPrefs.GetInt ("Coins") - 70000));
			coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		}

		levelSelectionScript.instance.lockGunButtons [i - 1].SetActive (false);
		levelSelectionScript.instance.lockGunButtons [i - 1].GetComponent<Button> ().enabled = false;
		levelSelectionScript.instance.PlayNext.interactable = true;

//		PlayerPrefs.SetInt ("Gun" + i + "Unlock", 1);
//		GameObject gun = GameObject.FindGameObjectWithTag ("gun");
//		gun.transform.GetChild (0).transform.gameObject.SetActive (false);
	}

	void ClearText(){
		lessCoin.text = "";
	}
}
