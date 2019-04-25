using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
	public GameObject Levels;
	public GameObject canvas;

	public LevelManager LevelManagement;
	public int EnemyNumber;
	public int WinCoins;
	public GameObject[] LevelCanvas;

	public GameObject[] fpsCanvas;
	public GameObject levelFinishCanvas;

	public static GameManager Instance;

	public Text headShot;
	public Text heartShot;
	public Text lungShot;

	public Text LevelReward;
	public Text TotalReward;

	public Text headShotlose;
	public Text heartShotlose;
	public Text lungShotlose;

	public Text LevelRewardlose;
	public Text TotalRewardlose;

	public Material nightSkybox;
	public Material snowSkybox;
	public Material grassSkybox;
	public Material desertSkybox;
	public Material SunnySkybox;

	public GameObject Indicator;
	public GameObject fire;
	public GameObject updown;

	public int indicatorTouchesCount;
	public int touch_;
	bool flag;

	public GameObject Light;

	void Awake (){
		Time.timeScale = 1;
		flag = true;
		touch_ = 0;

		if (PlayerPrefs.GetInt ("gameIndicator") == 0) {
			Indicator.SetActive (true);
			fire.SetActive (true);
			updown.SetActive (true);

		} else {
			Indicator.SetActive (false);
			fire.SetActive (false);
			updown.SetActive (false);
		}

	}

	void Update()
	{

		if (PlayerPrefs.GetInt ("gameIndicator") == 0) 
		{
			if (flag) 
			{
				if (Input.GetTouch(0).phase == TouchPhase.Ended) 
				{
					touch_++;
					Debug.Log (Input.touchCount); 

					if (touch_ > indicatorTouchesCount) 
					{
						Debug.Log ("Ahmad Don");
						Indicator.SetActive (false);
						fire.SetActive (false);
						updown.SetActive (false);
						flag = false;
						PlayerPrefs.SetInt ("gameIndicator", 1);
					}
				}
			}
		}
	}


	void ActivateLevel(){

		int CurrentLevel = PlayerPrefs.GetInt ("CurrentLevel");

		Levels.transform.GetChild (CurrentLevel).gameObject.SetActive(true);

//		if (PlayerPrefs.GetInt ("isGameStart") == 0) {
//			if (CurrentLevel == 1) {
//				indicators.SetActive (true);
//				PlayerPrefs.SetInt ("isGameStart", 1);
//			}
//		} else {
//			indicators.SetActive (false);
//
//		}


		if (CurrentLevel == 4 || CurrentLevel == 6) {
			RenderSettings.skybox = nightSkybox;
			RenderSettings.fogColor = new Color (0.012f, 0.408f, 0.463f, 1f);
			Light.GetComponent<Light> ().intensity = 0;
		} else if (CurrentLevel == 0 || CurrentLevel == 8 || CurrentLevel == 12) {
			RenderSettings.skybox = grassSkybox;
			RenderSettings.fogColor = new Color (0.61f, 0.85f, 0.89f, 1f);
			Light.GetComponent<Light> ().intensity = 1;
		} else if (CurrentLevel == 3 || CurrentLevel == 7 || CurrentLevel == 11 || CurrentLevel == 15) {
			RenderSettings.skybox = snowSkybox;
			Light.GetComponent<Light> ().intensity = 1;
			RenderSettings.fogColor = new Color (0.61f, 0.85f, 0.89f, 1f);
		} else if (CurrentLevel == 1 || CurrentLevel == 5 || CurrentLevel == 9 || CurrentLevel == 13) {
			RenderSettings.skybox = desertSkybox;
			Light.GetComponent<Light> ().intensity = 1;
			RenderSettings.fogColor = new Color (0.61f, 0.85f, 0.89f, 1f);
		} else {
			RenderSettings.skybox = SunnySkybox;
			Light.GetComponent<Light> ().intensity = 1;
			RenderSettings.fogColor = new Color (0.61f, 0.85f, 0.89f, 1f);
		}

		GameObject fpsmain = GameObject.FindGameObjectWithTag ("fpsmain");
		fpsmain.transform.GetChild (3).gameObject.GetComponent<PlayerWeapons> ().firstWeapon = PlayerPrefs.GetInt ("CurrentGun");
		fpsmain.transform.GetChild (3).gameObject.GetComponent<PlayerWeapons> ().weaponOrder [PlayerPrefs.GetInt ("CurrentGun")].GetComponent<WeaponBehavior> ().haveWeapon = true;

		LevelManagement = Levels.transform.GetChild (CurrentLevel).gameObject.GetComponent<LevelManager> ();
		EnemyNumber = LevelManagement.NumberOFEnemies;
		WinCoins = LevelManagement.WinCoins;
		this.GetComponent<AudioScript> ().OnGamePlay ();
		Time.timeScale = 1;
	}

	IEnumerator Start(){

		if (Instance == null) {
			Instance = this;
		}
		ActivateLevel ();

		yield return new WaitForSeconds (1f);
		Indicator.GetComponent<Animator> ().enabled = true;
		fire.GetComponent<Animator> ().enabled = true;
		updown.GetComponent<Animator> ().enabled = true;

	}

	public void OnClickBack(){
		SceneManager.LoadScene("LevelSelection");
	}

	public void OnRestart(){
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void KillEnemy(){
		bool once = true;
		if (once) {
			EnemyNumber = EnemyNumber - 1;
			CheckForWin ();
			once = false;
		}
	}

	public void CheckForWin(){
		if (EnemyNumber == 0){
			Invoke ("WinGame", 2.5f);
		}
	}

	void WinGame(){
		Debug.Log ("game manger win");
		int Coins = PlayerPrefs.GetInt ("Coins");
		if (LevelManagement.headShot == 0) {
			Coins = Coins + WinCoins;
		} else {
			Coins = Coins + WinCoins + LevelManagement.headShot * LevelManagement.headShotWin;
		}

		int treward = WinCoins + LevelManagement.headShot * LevelManagement.headShotWin;

		headShot.text = LevelManagement.headShot.ToString ();
		lungShot.text = LevelManagement.lungShot.ToString ();
		heartShot.text = LevelManagement.heartShot.ToString ();

		LevelReward.text ="Level Reward: "+ WinCoins.ToString ();
		TotalReward.text ="Total Reward: "+ treward.ToString ();

		PlayerPrefs.SetInt ("Coins", Coins);
		canvas.transform.GetChild (0).gameObject.SetActive (true);
		this.GetComponent<AudioScript> ().OnWin ();
		this.GetComponent<AudioSource> ().volume = 0.3f;


		int unlockLevel = PlayerPrefs.GetInt ("activeLevels"); // 0
		if (unlockLevel <= 15) {
			unlockLevel = unlockLevel + 1;
		}
		PlayerPrefs.SetInt ("activeLevels", unlockLevel);

//		PlayerPrefs.SetInt ("level" + (PlayerPrefs.GetInt ("CurrentLevel") + 1) + "Unlock", 1);

		LevelCanvas [PlayerPrefs.GetInt("CurrentLevel")].SetActive(false);

		levelFinishCanvas.transform.GetChild (0).gameObject.SetActive (true);

		fpsCanvas[PlayerPrefs.GetInt("CurrentLevel")].SetActive(false);
		Time.timeScale = 0f;

	}

	public void LoseGame(){
		Invoke ("Lose", 1f);
	}

	void Lose(){
		Debug.Log ("game manger lose");
		headShotlose.text = "0";
		lungShotlose.text = "0";
		heartShotlose.text ="0";

		LevelRewardlose.text = "Level Reward: " + "0";
		TotalRewardlose.text = "Total Reward: " + "0";

		this.GetComponent<AudioScript> ().OnLose ();
		this.GetComponent<AudioSource> ().volume = 0.3f;

		LevelCanvas [PlayerPrefs.GetInt("CurrentLevel")].SetActive(false);

		levelFinishCanvas.transform.GetChild (1).gameObject.SetActive (true);

		fpsCanvas[PlayerPrefs.GetInt("CurrentLevel")].SetActive(false);
		Time.timeScale = 0f;
	}
}