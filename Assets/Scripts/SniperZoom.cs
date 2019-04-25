using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SniperZoom : MonoBehaviour {
	public Slider zoom;
	public Image scope;
	public Camera weaponCamera;
	Vector3 initialValues;
	public GameObject FPSCamera;

	void Update () {
		FPSCamera.GetComponent<SmoothMouseLook> ().sensitivity = (zoom.value / 65) * 2;
		Camera.main.fieldOfView = zoom.value;
		if (zoom.value == 65f) {
			weaponCamera.enabled=true;
			scope.enabled = false;
		} else {
			scope.enabled = true;
			weaponCamera.enabled=false;
		}
	}
}
