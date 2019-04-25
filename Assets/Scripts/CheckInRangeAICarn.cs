//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.AI;
//
//public class CheckInRangeAICarn : MonoBehaviour {
//	static Animator anim;
//	public LayerMask detectionLayer;
//	private Transform mTransform;
//	private NavMeshAgent mNavMeshAgent;
//	private Collider[] hitColliders;
//	private float checkRate;
//	private float nextCheck;
//	private float detectionRadius = 100f;
//	public int health;
//	bool isDead;
//	public GameObject FPSPlayer;
//	public bool isFiredAt;
//
//	// Use this for initialization
//	void Start () {
//		mTransform = transform;
//		mNavMeshAgent = GetComponent<NavMeshAgent> ();
//		checkRate = Random.Range (0.8f, 1.2f);
//		anim = GetComponent<Animator> ();
//	}
//
//	// Update is called once per frame
//	void Update () {
//		if (!isDead) {
//			if (Time.time > nextCheck && mNavMeshAgent.enabled == true) {
//				nextCheck = Time.time + checkRate;
//				hitColliders = Physics.OverlapSphere (mTransform.position, detectionRadius, detectionLayer);
//
//				if (hitColliders.Length > 0) {	//if in range
//					mNavMeshAgent.SetDestination (hitColliders [0].transform.position);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", true);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
//
//					if (mNavMeshAgent.remainingDistance <= mNavMeshAgent.stoppingDistance && mNavMeshAgent.remainingDistance != 0) {
//						this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
//						this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
//						this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
//						this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
//						this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", true);
//						FPSPlayer.gameObject.transform.parent.gameObject.GetComponent<FPSPlayer> ().hitPoints = FPSPlayer.gameObject.transform.parent.gameObject.GetComponent<FPSPlayer> ().hitPoints - 10f;
//						GameManager.Instance.LoseGame ();
//					}
//				} else {
//					this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", true);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isDead", false);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
//					this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
//				}
//			}
//		} else {
//			this.gameObject.GetComponent<Animator> ().SetBool ("isRunning", false);
//			this.gameObject.GetComponent<Animator> ().SetBool ("isIdle", false);
//			this.gameObject.GetComponent<Animator> ().SetBool ("isDead", true);
//			this.gameObject.GetComponent<Animator> ().SetBool ("isBiting", false);
//			this.gameObject.GetComponent<Animator> ().SetBool ("isWalking", false);
//			Invoke ("DestroyAnimation", 2f);
//		}
//	}
//
//	void DestroyAnimation(){
//		this.gameObject.GetComponent<Animator> ().enabled = false;
//		this.gameObject.GetComponent<NavMeshAgent> ().enabled = false;
//		Destroy (this.gameObject, 5f);
//	}
//
//	public void TakeDamage(int damage){
//		if (damage >= health) {
//			health = 0;
//			isDead = true;
//			GameManager.Instance.KillEnemy ();
//			//TYU
//		}
//		else
//			health = health - damage;
//	}
//}
