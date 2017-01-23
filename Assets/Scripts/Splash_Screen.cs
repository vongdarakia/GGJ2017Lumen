using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Splash_Screen : MonoBehaviour {
	float time;

	// Use this for initialization
	void Start () {
		time = 4.0f;
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0)
			Application.LoadLevel ("diamondback");
	}
}
