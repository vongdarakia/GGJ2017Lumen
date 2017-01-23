using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSoundEvent : MonoBehaviour {
	public LinkedList<DynamicLight2D.DynamicLight> playerSounds;
	private GameObject[] objects;

	IEnumerator Start () {
		objects = GameObject.FindGameObjectsWithTag ("Sound");
		playerSounds = new LinkedList<DynamicLight2D.DynamicLight> ();

//		print ("HIHIHI " + objects.Length);
		for (int i = 0; i < objects.Length; i++) {
			playerSounds.AddLast(objects[i].GetComponent<DynamicLight2D.DynamicLight>() as DynamicLight2D.DynamicLight);
		}

		foreach (DynamicLight2D.DynamicLight sound in playerSounds) {
			sound.OnExitFieldOfView += onExit;
			sound.OnEnterFieldOfView += onEnter;
		}

		yield return new WaitForEndOfFrame();
		//		StartCoroutine(loop());

	}

	// Update is called once per frame
	//	void Update () {
	//		
	//	}

	void onExit(GameObject g, DynamicLight2D.DynamicLight sound){
		print ("wtf");
		if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
//			Debug.Log("Enemy Lost You By Sound");
			Enemy e = g.GetComponentInParent<Enemy> ();
			Player p = sound.GetComponentInParent<Player>();

			e.soundTargets.Remove(p);
//			print ("Targets: " + e.targets.Count);
			print ("Lost by Sound | Targets: " + e.soundTargets.Count);

		}
	}

	void onEnter(GameObject g, DynamicLight2D.DynamicLight sound){
		print ("yes");

		if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
//			Debug.Log("Enemy Found You By Sound");
			Enemy e = g.GetComponentInParent<Enemy> ();

			Player p = sound.GetComponentInParent<Player>();
//			print (g.name);

			if (!e.soundTargets.Contains (p)) {
				e.soundTargets.AddLast (p);
//				print ("Targets: " + e.targets.Count);
				print ("Found by Sound | Targets: " + e.soundTargets.Count);
			}

		}
	}
}
