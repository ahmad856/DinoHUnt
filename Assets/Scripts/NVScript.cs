using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NVScript : MonoBehaviour {
	bool nightVision;

	void Start(){
		nightVision = false;
	}
	
	public void OnNVClick(){
		if (nightVision) {
			Camera.main.GetComponent<CameraEffect> ().m_Enable = false;
			nightVision = false;
		} else {
			Camera.main.GetComponent<CameraEffect> ().m_Enable = true;
			nightVision = true;
		}
	}
}
