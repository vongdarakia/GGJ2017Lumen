using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterCaught : MonoBehaviour {

	public AudioClip chasingSound;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other) {

		if (other.name == "Character") {
			SoundManager.instance.PlaySingle (chasingSound);

		}

	}

//	void OnTriggerEnter2D(Collider2D other) {
//		characterInQuicksand = true;
//	}
}
