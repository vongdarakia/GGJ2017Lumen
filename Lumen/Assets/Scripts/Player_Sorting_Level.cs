using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Sorting_Level : MonoBehaviour {

	public Renderer playerRenderer;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerRenderer.sortingOrder = 3;
		}
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
			playerRenderer.sortingOrder = 1;
		}
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {

	}
}
