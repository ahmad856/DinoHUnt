using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DinoAI : MonoBehaviour {
	public Transform dest1;
	public Transform dest2;
	public Transform safePoint;
	public bool isFiredAt;
	bool reachedDest;
	public int health;
	bool isDead;

	bool idle = false;
	bool die = false;
	bool walk = false;
	bool run = false;

	public float speed;

	public bool headShot=false;
	public bool lungShot=false;
	public bool heartShot=false;

	public bool isSafePoint;

	// Use this for initialization
	void Start () {
		health = 100;
		isFiredAt = false;
		isDead = false;
		this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (dest1.position);
	}
	
	// Update is called once per frame
	void Update () {
		if (!idle) {
			
			if (this.GetComponent<DinoAudioScript> ().audioOn) {
				this.GetComponent<AudioSource> ().volume = 0.3f;
			} else {
				this.GetComponent<AudioSource> ().volume = 0f;
			}
		} else {
			this.GetComponent<AudioSource> ().volume = 0f;
		}
		if (!isDead) {
			if (!isFiredAt) {
				//reached Destination
				if (this.gameObject.GetComponent<NavMeshAgent> ().remainingDistance > 0f) {
					if (!walk) {
						//walking animation
						this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", true);
						walk = true;
						die = idle = run = false;
						this.GetComponent<DinoAudioScript> ().OnWalk ();
					}
				} else {
					//Idle animation
					if (!idle) {
						this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", true);
						this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
						idle = true;
						die = walk = run = false;
					}
					if (Vector3.Distance (this.gameObject.transform.position, dest1.position) < 3f) {
						if (isSafePoint) {
							//you loose
							GameManager.Instance.LoseGame();
							Debug.Log ("lose game function called");

						} else
							Invoke ("Dest2", 5f);
					}
				}
			} else {
				//running animation
				if (!run) {
					this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", true);
					this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
					this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
					this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
					this.GetComponent<DinoAudioScript> ().OnRun ();

					run = true;
					die = false;
					idle = false;
					if (this.gameObject.GetComponent<NavMeshAgent> ().hasPath) {
						this.gameObject.GetComponent<NavMeshAgent> ().ResetPath();
						if (safePoint != null) {
							this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (safePoint.position);
						} else {
							this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (dest2.position);
						}
						this.gameObject.GetComponent<NavMeshAgent> ().speed = speed;
					}
				}

				if (Vector3.Distance (this.gameObject.transform.position, safePoint.position) < 3f) {
					//game over
					GameManager.Instance.LoseGame();
					Debug.Log ("lose game function called");
				}
			}
		} else {
			//dead animation
			if (!die) {
				this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
				this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
				this.gameObject.GetComponent<Animator> ().SetBool ("isDead", true);
				this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
				die = true;
				this.GetComponent<DinoAudioScript> ().OnDeath ();

			}
			Invoke ("DestroyAnimation", 2f);
			//Destroy (this.gameObject, 2f);
		}
	}

	void Dest2(){
		this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (dest2.position);
	}

	void DestroyAnimation(){
		this.gameObject.GetComponent<Animator> ().enabled = false;
		this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;

		Destroy (this.gameObject, 5f);
	}

	public void TakeDamage(int damage){
		if (!isDead) {
			if (damage >= health) {
				health = 0;
				isDead = true;
				//TYU
				GameManager.Instance.KillEnemy ();

			}
			else
				health = health - damage;
		}
	}
}
