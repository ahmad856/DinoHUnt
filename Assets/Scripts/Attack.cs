using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour {
	public GameObject[] carn;

	// Use this for initialization
	void Start () {
		for (int i = 0; i < carn.Length; i++) {
			carn [i].GetComponent<DinoCarnAi> ().isFiredAt = true;
		}
	}
}
