using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightDetection : MonoBehaviour {

	public LinkedList<DynamicLight2D.DynamicLight> flashlights;
	private GameObject[] objects;

	IEnumerator Start () {
		objects = GameObject.FindGameObjectsWithTag ("Flashlight");
		flashlights = new LinkedList<DynamicLight2D.DynamicLight> ();

		for (int i = 0; i < objects.Length; i++) {
			flashlights.AddLast(objects[i].GetComponent<DynamicLight2D.DynamicLight>() as DynamicLight2D.DynamicLight);
		}

		foreach (DynamicLight2D.DynamicLight view in flashlights) {
			view.OnExitFieldOfView += onExit;
			view.OnEnterFieldOfView += onEnter;
		}

		yield return new WaitForEndOfFrame();
		//		StartCoroutine(loop());

	}

	// Update is called once per frame
	//	void Update () {
	//		
	//	}

	void onExit(GameObject g, DynamicLight2D.DynamicLight flashlight){

		if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
			//			Debug.Log("Enemy Lost You");
			Player otherPlayer = g.GetComponentInParent<Player> ();
			Player playerShiningLight = flashlight.GetComponentInParent<Player>();

			print ("Player left your light");
//			e.visionTargets.Remove(p);
//			print ("Lost by Sight | Targets: " + e.visionTargets.Count);
		}
	}

	void onEnter(GameObject g, DynamicLight2D.DynamicLight flashlight){

		if (gameObject.GetInstanceID () == g.GetInstanceID ()) {

			//			print (g.name);
			Player otherPlayer = g.GetComponentInParent<Player> ();
			Player playerShiningLight = flashlight.GetComponentInParent<Player>();

//			if (!p.flashlight.GetComponent<Renderer>().gameObject.activeSelf)
//				return;
			print ("Player is in your light");
//			Enemy e = enemyVision.GetComponentInParent<Enemy>();
			//			print (e.name);
//			if (!e.visionTargets.Contains(p))
//				e.visionTargets.AddLast (p);
//			print ("Found by Sight | Targets: " + e.visionTargets.Count);

		}
	}
}
