using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTargetEvent : MonoBehaviour {
	public LinkedList<DynamicLight2D.DynamicLight> enemyViews;
	private GameObject[] objects;

	IEnumerator Start () {
		objects = GameObject.FindGameObjectsWithTag ("EnemyView");
		enemyViews = new LinkedList<DynamicLight2D.DynamicLight> ();

		for (int i = 0; i < objects.Length; i++) {
			enemyViews.AddLast(objects[i].GetComponent<DynamicLight2D.DynamicLight>() as DynamicLight2D.DynamicLight);
		}
			
		foreach (DynamicLight2D.DynamicLight view in enemyViews) {
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

	void onExit(GameObject g, DynamicLight2D.DynamicLight enemyVision){
		
		if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
//			Debug.Log("Enemy Lost You");
			Player p = g.GetComponentInParent<Player> ();
			Enemy e = enemyVision.GetComponentInParent<Enemy>();

			e.visionTargets.Remove(p);
			print ("Lost by Sight | Targets: " + e.visionTargets.Count);
		}
	}

	void onEnter(GameObject g, DynamicLight2D.DynamicLight enemyVision){

		if (gameObject.GetInstanceID () == g.GetInstanceID ()) {
			
//			print (g.name);
			Player p = g.GetComponentInParent<Player> ();
			print (p.flashlight);
			if (!p.flashlight || (p.flashlight && !p.flashlight.GetComponent<Renderer>().gameObject.activeSelf))
				return;

			Enemy e = enemyVision.GetComponentInParent<Enemy>();
//			print (e.name);
			if (!e.visionTargets.Contains(p))
				e.visionTargets.AddLast (p);
			print ("Found by Sight | Targets: " + e.visionTargets.Count);

		}
	}
}
