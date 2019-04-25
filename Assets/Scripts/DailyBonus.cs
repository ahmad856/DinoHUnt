using System;
using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;



public class DailyBonus : MonoBehaviour 
{

	public Button[] days7Reward;
	public string stringLastDate;
	public GameObject panel;
	public Text coins;


	void Start()
	{
		CheckDailyBonus ();
	}

	void CheckDailyBonus ()
	{
//		PlayerPrefs.DeleteAll ();

		DateTime currDate = System.DateTime.Now;
		if (PlayerPrefs.GetString("LastPlayedDate") == "") 
		{
			PlayerPrefs.SetString("LastPlayedDate",currDate.ToString());
		}


		stringLastDate = PlayerPrefs.GetString ("LastPlayedDate");
		DateTime lastDate = Convert.ToDateTime (stringLastDate);


		print ("Last Day: " + lastDate);
		print ("Curr Day: " + currDate);


		TimeSpan difference = currDate.Subtract (lastDate);
		print ("Days : " + difference.Days);

		if (difference.Days == 0) {
			if (PlayerPrefs.GetInt ("ClaimedReward") == 0)
				panel.gameObject.SetActive (true);

			string newStringDate = Convert.ToString (currDate);

			PlayerPrefs.SetString ("LastPlayedDate", newStringDate);
			PlayerPrefs.SetInt ("ContinousDays", PlayerPrefs.GetInt ("ContinousDays") + difference.Days);

		}
			
		if (difference.Days == 1) 
		{
			panel.gameObject.SetActive (true);
			print ("New Reward Today");
			string newStringDate = Convert.ToString (currDate);

			PlayerPrefs.SetString ("LastPlayedDate", newStringDate);
			PlayerPrefs.SetInt ("ContinousDays", PlayerPrefs.GetInt ("ContinousDays") + difference.Days);
			print ("ContinousPlayed days : " + PlayerPrefs.GetInt ("ContinousDays"));
		
			//Give Daily Reward
			print ("New Date Added");
		}
		else
		{
			//Reset Daily Reward
			print ("Resetting");
			PlayerPrefs.SetInt("ContinousDays",0);
		}

		for (int i = 0; i < days7Reward.Length; i++) 
		{
			print ("InLoop");
			if (i == PlayerPrefs.GetInt ("ContinousDays")) 
			{
				print ("Week Days");
				days7Reward [i].interactable = true;
			}
			else if (PlayerPrefs.GetInt ("ContinousDays") > days7Reward.Length - 1) 
			{
				print ("Over Week");
				days7Reward [days7Reward.Length - 1].interactable = true;
			}
		}

	}

	void OnApplicationPause(bool pauseStatus)
	{
		if (pauseStatus) {
			DateTime currDate = System.DateTime.Now;
			PlayerPrefs.SetString ("LastPlayedDate", currDate.ToString ());
		} else {
			CheckDailyBonus ();
		}
	}

	public void ClaimRewad(int reward){
		
		if (PlayerPrefs.GetInt ("ClaimedReward") == 0) {

			int Coins = PlayerPrefs.GetInt ("Coins");
			Coins = Coins + reward;
			coins.text = Coins.ToString ();
			PlayerPrefs.SetInt ("Coins", Coins);

			PlayerPrefs.SetInt ("ClaimedReward", 1);
		}

		panel.gameObject.SetActive (false);
	}
}