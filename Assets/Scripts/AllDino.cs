using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllDino : MonoBehaviour {

	public GameObject[] carn;
	public GameObject[] herb;
	bool attack;
	
	// Update is called once per frame
	void Update () {
		for (int i = 0; i < herb.Length; i++) {
			if (herb [i].GetComponent<DinoAI> ().isFiredAt) {
				attack = true;
				break;
			}
		}

		for (int i = 0; i < carn.Length; i++) {
			if (carn [i].GetComponent<DinoCarnAi> ().isFiredAt) {
				attack = true;
				break;
			}
		}

		if (attack) {
			for (int i = 0; i < herb.Length; i++) {
				herb [i].GetComponent<DinoAI> ().isFiredAt = true;
			}
			for (int i = 0; i < carn.Length; i++) {
				carn [i].GetComponent<DinoCarnAi> ().isFiredAt = true;
			}
		}
	}
}
