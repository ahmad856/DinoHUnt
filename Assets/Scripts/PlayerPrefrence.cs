using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefrence: MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (!PlayerPrefs.HasKey ("level1Unlock") && !PlayerPrefs.HasKey ("gun1Unlock")) {
			
			PlayerPrefs.SetInt ("Gun1Unlock", 1);
			PlayerPrefs.SetInt ("Gun2Unlock", 0);
			PlayerPrefs.SetInt ("Gun3Unlock", 0);
			PlayerPrefs.SetInt ("Gun4Unlock", 0);
			PlayerPrefs.SetInt ("Gun5Unlock", 0);
			PlayerPrefs.SetInt ("Gun6Unlock", 0);
			PlayerPrefs.SetInt ("Gun7Unlock", 0);
		}
	}
}
