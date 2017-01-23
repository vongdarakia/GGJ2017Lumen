using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

	public LinkedList<Player> visionTargets;
	public LinkedList<Player> soundTargets;
	Player player;
//	public AudioSource soundefx;
	public AudioClip chasingSound;

	void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "Player") {
//			Destroy (other.gameObject);
			Application.LoadLevel ("Gameover");
		}
	}

	// Use this for initialization
	void Start () {
		soundTargets = new LinkedList<Player> ();
		visionTargets = new LinkedList<Player> ();
//		player = GameObject.FindGameObjectWithTag ("Player").GetComponent<Player>();
//		print (player);
	}


	// Update is called once per frame
	void Update () {
//		float dist = Vector3.Distance (player.transform.position, transform.position);
//		if (dist < 300) {
			
//			SoundManager.instance.PlaySingle (chasingSound);
//		}
			
			
	}

	public Player GetClosestPlayerBySight() {
		if (visionTargets.Count == 0)
			return null;
		if (visionTargets.Count == 1)
			return visionTargets.First.Value;
		float shortest = Vector3.Distance (visionTargets.First.Value.gameObject.transform.position, transform.position);
		Player closest = visionTargets.First.Value;

		foreach (Player target in visionTargets) {
			float dist = Vector3.Distance (target.gameObject.transform.position, transform.position);

			if (dist < shortest) {
				shortest = dist;
				closest = target;
			}
		}
		return closest;
	}

	public Player GetClosestPlayerBySound() {
		if (soundTargets.Count == 0)
			return null;
		if (soundTargets.Count == 1)
			return visionTargets.First.Value;
		float shortest = Vector3.Distance (soundTargets.First.Value.gameObject.transform.position, transform.position);
		Player closest = soundTargets.First.Value;

		foreach (Player target in soundTargets) {
			float dist = Vector3.Distance (target.gameObject.transform.position, transform.position);

			if (dist < shortest) {
				shortest = dist;
				closest = target;
			}
		}
		return closest;
	}

	public Player GetClosest() {
		Player closestVision = GetClosestPlayerBySight ();
		Player closestSound = GetClosestPlayerBySound ();

		if (!closestVision && !closestSound) {
			Player[] players = GameObject.FindObjectsOfType<Player>();

			if (players.Length == 0)
				return null;
			float shortest = Vector3.Distance (players[0].gameObject.transform.position, transform.position);
			Player closest = players[0];

			foreach (Player target in players) {
				float dist = Vector3.Distance (target.gameObject.transform.position, transform.position);

				if (dist < shortest) {
					shortest = dist;
					closest = target;
				}
			}
//			print ("WTF");
			return closest;
		}
		if (!closestVision)
			return closestSound;
		if (!closestSound)
			return closestVision;
		float soundDist = Vector3.Distance (closestSound.gameObject.transform.position, transform.position);
		float sightDist = Vector3.Distance (closestVision.gameObject.transform.position, transform.position);

		if (soundDist < sightDist)
			return closestSound;
		return closestVision;
	}
}
