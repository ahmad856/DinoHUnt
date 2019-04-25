using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastEnemy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<InputControl> ().fireHold) {
//			RaycastHit hit;
//			if (Physics.Raycast (transform.position, transform.TransformDirection (Vector3.forward), out hit, Mathf.Infinity, layer)) {
//				Debug.DrawRay (Camera.main.transform.position, Camera.main.transform.TransformDirection (Vector3.forward) * hit.distance, Color.red);
//				Debug.Log ("Hit Confirm");
//			} else {
//				Debug.DrawRay (Camera.main.transform.position, Camera.main.transform.TransformDirection (Vector3.forward) * hit.distance, Color.white);
//				Debug.Log ("No Hit");
//			}
		}
	}
}
