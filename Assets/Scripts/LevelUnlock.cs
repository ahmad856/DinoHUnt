using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelUnlock : MonoBehaviour {
	public Image [] levels;

	void Awake(){

		int unlockLevel = PlayerPrefs.GetInt ("activeLevels"); // 1
		for (int i = 0; i <= unlockLevel; i++) {
			levels [i].gameObject.SetActive (false);

		}

	}

	void Start () {
//		for (int i = 0; i < levels.Length; i++) {
//
//			Debug.Log ("Level :" + (i+1));
//			Debug.Log (PlayerPrefs.GetInt ("level" + (i + 1) + "Unlock"));
//
//			if (PlayerPrefs.GetInt ("level" + (i + 1) + "Unlock") == 1) {
////				levels [i].enabled = false;	
//			}
//		}	
//	}
	}
}
