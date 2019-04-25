using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FiredAt : MonoBehaviour {
	public GameObject[] dino;
	bool attack;

	// Update is called once per frame
	void Update () {
		if (!attack) {
			for (int i = 0; i < dino.Length; i++) {
				if (dino [i].GetComponent<DinoCarnAi> ().isFiredAt) {
					attack = true;
					break;
				}
			}
			for (int i = 0; i < dino.Length; i++) {
				dino [i].GetComponent<DinoCarnAi> ().isFiredAt = true;
			}
		}
	}
}
