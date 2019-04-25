using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.ImageEffects;

public class IRScript : MonoBehaviour {
	bool infraRed;

	void Start(){
		infraRed = false;
	}

	public void OnIRClick(){
		if (infraRed) {
			Camera.main.GetComponent<ColorCorrectionLookup> ().enabled = false;
			infraRed = false;
		} else {
			Camera.main.GetComponent<ColorCorrectionLookup> ().enabled = true;
			infraRed = true;
		}
	}
}
