using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour {
	public void UpdateMoney (int coins) {
		int CurrentCoins = PlayerPrefs.GetInt ("Coins");
		CurrentCoins += coins;
		PlayerPrefs.SetInt ("Coins", CurrentCoins);
	}
}
