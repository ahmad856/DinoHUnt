using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class myGameManager : MonoBehaviour {

	public static myGameManager Instance;

	public static bool isSoundActive;

	void Awake()
	{
		Instance = this;
	}

	static myGameManager()
	{
		isSoundActive = true;
	}
}
