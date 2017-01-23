using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logo_Screen : MonoBehaviour {
	
	float time;

	// Use this for initialization
	void Start () {
		time = 3.0f;
	}

	// Update is called once per frame
	void Update () {
		time -= Time.deltaTime;
		if (time <= 0)
			Application.LoadLevel ("Splash");
	}
}
