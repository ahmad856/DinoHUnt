using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.ImageEffects;

public class UpdateMaterial : MonoBehaviour {

	public Material opaqueMat;
	public Material transparentMat;
	private Renderer rend;

	// Use this for initialization
	void Awake () {
		rend = GetComponent<Renderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Camera.main.GetComponent<ColorCorrectionLookup> ().enabled) {
			rend.material = transparentMat;
		} else {
			rend.material = opaqueMat;
		}
	}
}
