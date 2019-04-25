using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class DinoCarnAi : MonoBehaviour {
	public Transform dest1;
	public Transform dest2;
	public bool isFiredAt;
	bool reachedDest;
	public int health;
	bool isDead;
	public GameObject FPSPlayer;
	public Image blood;

	bool idle;
	bool die;
	bool walk;
	bool run;
	bool bite;

	public float speed;


	public bool headShot=false;
	public bool lungShot=false;
	public bool heartShot=false;

	// Use this for initialization
	void Start () {
		health = 100;
		isFiredAt = false;
		isDead = false;
		idle = false;
		die = false;
		walk = false;
		run = false;
		bite = false;
		if (dest1 == null && dest2 == null) {
			isFiredAt = true;
			this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (FPSPlayer.transform.position);
		} else if (dest2 == null) {
			dest2 = this.gameObject.transform;
		} else {
			this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (dest1.position);
		}
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
						this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
						walk = true;
						idle = die = run = false;
						this.GetComponent<DinoAudioScript> ().OnWalk ();
					}
				} else {
					if (!idle) {
						//Idle animation
						this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", true);
						this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
						idle = true;
						die = walk = run = false;
					}

					if (Vector3.Distance (this.gameObject.GetComponent<NavMeshAgent> ().destination, dest1.position) < 1f) {
						Invoke ("Dest2", 5f);
					}
				}
			} else {
				//running animation
				if(!run){
					this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", true);
					this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
					this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
					this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
					this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
					run = true;
					die = bite = false;
					idle = false;
					this.GetComponent<DinoAudioScript> ().OnRun ();
				}

				if (this.gameObject.GetComponent<NavMeshAgent> ().hasPath) {
					this.gameObject.GetComponent<NavMeshAgent> ().ResetPath ();
					this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (FPSPlayer.transform.position);
					this.gameObject.GetComponent<NavMeshAgent> ().speed = speed;
				} else {
					this.gameObject.GetComponent<NavMeshAgent> ().SetDestination (FPSPlayer.transform.position);
					this.gameObject.GetComponent<NavMeshAgent> ().speed = speed;
				}
				if (this.gameObject.GetComponent<NavMeshAgent> ().remainingDistance < 2f && this.gameObject.GetComponent<NavMeshAgent> ().remainingDistance != 0) {
					if (!bite) {
						//biting
						this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
						this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", true);
						bite = true;
						die = false;

						this.GetComponent<DinoAudioScript> ().OnAttack ();
						FPSPlayer.gameObject.transform.parent.gameObject.GetComponent<FPSPlayer> ().hitPoints = FPSPlayer.gameObject.transform.parent.gameObject.GetComponent<FPSPlayer> ().hitPoints - 110f;
						blood.enabled = true;
						GameManager.Instance.LoseGame ();
						Debug.Log ("lose game function called");

					}
				}
			}
		} else {
			if(!die){
				//dead animation
				this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
				this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
				this.gameObject.GetComponent<Animator> ().SetBool ("isDead", true);
				this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
				this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
				die = true;
				this.GetComponent<DinoAudioScript> ().OnDeath ();

			}
			Invoke ("DestroyAnimation", 2f);
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
				GameManager.Instance.KillEnemy ();
				//TYU
			}
			else
				health = health - damage;
		}
	}
}
