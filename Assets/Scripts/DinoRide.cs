using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoRide : MonoBehaviour {

	public Transform dinorideDest;
	bool walking;
	bool reached;

	// Use this for initialization
	void Start () {
		this.GetComponent<NavMeshAgent> ().SetDestination (dinorideDest.position);
		reached = false;
		walking = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.GetComponent<NavMeshAgent> ().remainingDistance > 2f) {
			if (!walking) {
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<Animator> ().SetBool ("isWalking", true);
				this.gameObject.transform.GetChild (0).gameObject.GetComponent<DinoAudioScript> ().OnWalk ();
				walking = true;
			}
		} else if(this.gameObject.GetComponent<NavMeshAgent> ().remainingDistance < 2f && this.gameObject.GetComponent<NavMeshAgent> ().remainingDistance > 0f){
			if (!reached) {
				if (GameManager.Instance.EnemyNumber > 0) {
					GameManager.Instance.LoseGame ();
				}
				reached = true;
			}
		}
	}
}
