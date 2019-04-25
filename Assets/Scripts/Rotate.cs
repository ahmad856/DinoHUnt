using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Rotate : MonoBehaviour {

	void Start()
	{
		Time.timeScale = 1;
	}

	void Update () {
		transform.Rotate (0f, 360f * Time.deltaTime * 0.15f, 0f);
	}
}
