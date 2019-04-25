using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class levelSelectionScript : MonoBehaviour {

	public static levelSelectionScript instance;

	public Image nightvision;
	public Image infraRed;

	public List <GameObject> myGuns;
	public Button PlayNext;

	public GameObject nextBtn;
	public GameObject backBtn;
	public int index;

	public List<int> power;
	public List<int> zoom;
	public List<int> stability;
	public List<int> capacity;

	public List<Image> mods;

	public Text pow;
	public Text zooom;
	public Text stab;
	public Text cap;

	public Text coins;

	public Button M4A1;
	public Button SVD;
	public Button Sniper;
	public Button SniperAWp;
	public Button unlockAllGuns;

	public Text gunChange;

	public Text LessCoins;

	public List <GameObject> lockGunButtons;


	void Awake()
	{
		instance = this;
		PlayerPrefs.SetInt ("lockButton 0", 1);

	}


	void Start(){
		Time.timeScale = 1;
		coins.text = PlayerPrefs.GetInt ("Coins").ToString ();
		PlayerPrefs.SetInt ("CurrentGun", 1);

//		InvokeRepeating ("Rotate", 0.000000001f, 0.0000001f);
	}

	public void nextBtnFun(){

		for (int k = 0; k < lockGunButtons.Count; k++) {
		
			lockGunButtons [k].SetActive (false);
		
		}

		unlockAllGuns.gameObject.SetActive(false);
		SniperAWp.gameObject.SetActive (false);
		Sniper.gameObject.SetActive (false);
		SVD.gameObject.SetActive (false);
		M4A1.gameObject.SetActive (false);
		gunChange.text = "";
		LessCoins.text = "";
		myGuns [index].SetActive(false);
//		iTween.MoveTo (myGuns [index], iTween.Hash ("x", -160f, "time", 0.5f, "easetype", iTween.EaseType.linear, "islocal", true));
		index++;



		if (PlayerPrefs.GetInt ("lockButton " + index) == 0) {
			lockGunButtons [index].SetActive (true);
			lockGunButtons [index].GetComponent<Image> ().enabled = true;
			lockGunButtons [index].GetComponent<Button> ().enabled = true;
			PlayNext.interactable = false;
		} else {
			lockGunButtons [index].SetActive (false);
			PlayNext.interactable = true;
			lockGunButtons [index].GetComponent<Image> ().enabled = false;
			lockGunButtons [index].GetComponent<Button> ().enabled = false;
		}
		
				


		pow.text=power[index].ToString();
		zooom.text=zoom[index].ToString();
		stab.text=stability[index].ToString();
		cap.text=capacity[index].ToString();
//		iTween.MoveTo (myGuns[index], iTween.Hash ("x",0f,"time", 0.5f, "easetype", iTween.EaseType.linear, "islocal", true));
		myGuns [index].SetActive(true);
		if (index == 0) {
			nightvision.enabled = false;
			infraRed.enabled = false;
		} else {
			nightvision.enabled = true;
			infraRed.enabled = true;
		}

		PlayerPrefs.SetInt ("CurrentGun", (index + 1));
//		if (PlayerPrefs.GetInt ("Gun" + (index + 1) + "Unlock") == 1) {
//			myGuns [index].transform.GetChild (0).transform.gameObject.SetActive (false);
//		}

		if (index == (myGuns.Count - 1)) {
			nextBtn.GetComponent<Button> ().enabled = false;
			nextBtn.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0.5f);

			backBtn.GetComponent<Button> ().enabled = true;
			backBtn.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		} else {
			backBtn.GetComponent<Button> ().enabled = true;
			backBtn.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		}
	}

	public void backBtnFun(){

		for (int k = 0; k < lockGunButtons.Count; k++) {

			lockGunButtons [k].SetActive (false);

		}

		unlockAllGuns.gameObject.SetActive(false);
		SniperAWp.gameObject.SetActive (false);
		Sniper.gameObject.SetActive (false);
		SVD.gameObject.SetActive (false);
		M4A1.gameObject.SetActive (false);
		gunChange.text = "";
		LessCoins.text = "";
		myGuns [index].SetActive(false);
//		iTween.MoveTo (myGuns[index], iTween.Hash ("x",160f,"time", 0.5f, "easetype", iTween.EaseType.linear, "islocal", true));
		index--;

		if (PlayerPrefs.GetInt ("lockButton " + index) == 0) {
			lockGunButtons [index].SetActive (true);
			lockGunButtons [index].GetComponent<Image> ().enabled = true;
			lockGunButtons [index].GetComponent<Button> ().enabled = true;
			PlayNext.interactable = false;

		} else {
			lockGunButtons [index].SetActive (false);
			PlayNext.interactable = true;

			lockGunButtons [index].GetComponent<Image> ().enabled = false;
			lockGunButtons [index].GetComponent<Button> ().enabled = false;
		}


		pow.text=power[index].ToString();
		zooom.text=zoom[index].ToString();
		stab.text=stability[index].ToString();
		cap.text=capacity[index].ToString();
//		iTween.MoveTo (myGuns[index], iTween.Hash ("x",0f,"time", 0.5f, "easetype", iTween.EaseType.linear, "islocal", true));
		myGuns [index].SetActive(true);

		if (index == 0) {
			nightvision.enabled = false;
			infraRed.enabled = false;
		} else {
			nightvision.enabled = true;
			infraRed.enabled = true;
		}

		PlayerPrefs.SetInt ("CurrentGun", (index + 1));
//		if (PlayerPrefs.GetInt ("Gun" + (index + 1) + "Unlock") == 1) {
//			myGuns [index].transform.GetChild (0).transform.gameObject.SetActive (false);
//		}

		if (index == 0) {
			nextBtn.GetComponent<Button> ().enabled = true;
			nextBtn.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
			backBtn.GetComponent<Button> ().enabled = false;
			backBtn.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 0.5f);
		} else {
			nextBtn.GetComponent<Button> ().enabled = true;
			nextBtn.GetComponent<Image> ().color = new Color (1f, 1f, 1f, 1f);
		}
	}


	void Update()
	{
		foreach (GameObject item in myGuns) {
			item.transform.Rotate(0f, 360f * Time.deltaTime * 0.15f, 0f);
		}
	}

}
