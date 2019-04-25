using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NighVision : MonoBehaviour {

	public Material opaqueMat;
	public Material transparentMat;
	private Renderer rend;

	// Use this for initialization
	void Awake () {
		rend = GetComponent<Renderer> ();
	}

	// Update is called once per frame
	void Update () {
		if (Camera.main.GetComponent<CameraEffect> ().m_Enable == true) {
			rend.material = transparentMat;
		} else {
			rend.material = opaqueMat;
		}
	}
}
