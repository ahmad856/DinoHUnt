using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class EnableBoxCollider : MonoBehaviour {
	public GameObject parent;
	// Update is called once per frame
	void Update () {
		if (Camera.main.GetComponent<ColorCorrectionLookup> ().enabled) {
			this.GetComponent<BoxCollider> ().enabled = true;
		} else {
			this.GetComponent<BoxCollider> ().enabled = false;
		}
	}
}
