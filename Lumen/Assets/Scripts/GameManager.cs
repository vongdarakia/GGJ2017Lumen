using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {
	public static GameManager instance = null;

	public Player player = null;
	public float timeLeft;
	public bool gamePlaying;

	// Use this for initialization
	void Start () {
		// Loads players in map.
		gamePlaying = false;
		InitGame ();
	}

	void Awake() {
		if (instance == null)
			instance = this;
		else if (instance != this)
			Destroy (gameObject);
		// Keep data alive between scenes.
		DontDestroyOnLoad (gameObject);
	}

	void InitGame()
	{
		gamePlaying = true;
		timeLeft = 10.0f;

	}
	// Update is called once per frame
	void Update () {
//		if (gamePlaying) {
//			timeLeft -= Time.deltaTime;
//			if (timeLeft <= 0)
//				gamePlaying = false;
//			print (timeLeft);
//		}
	}
}
