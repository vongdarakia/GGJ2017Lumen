using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DynamicLight2D;

public class Player : MonoBehaviour {


	public float speed;
	public float runSpeedMultiplier;

	private float runSpeed;
	public DynamicLight2D.DynamicLight flashlight;
	private bool lightOn;
	private bool isWalking;
	public AudioClip moveSound;
	public bool soundPlaying;
//	private SoundManager sm;

	// Use this for initialization
	void Start () {
		isWalking = false;
		soundPlaying = false;
//		sm = new SoundManager ();

		DynamicLight2D.DynamicLight[] lights = GetComponentsInChildren<DynamicLight2D.DynamicLight>();

		foreach (DynamicLight2D.DynamicLight light in lights) {
			if (light.tag == "Flashlight") {
				flashlight = light;
				break;
			}
		}
//			/GameObject.Find("PlayerLight").GetComponent<DynamicLight2D.DynamicLight> () as DynamicLight2D.DynamicLight;
	}
	
	// Update is called once per frame
	void Update () {
//		Vector3 position = this.transform.position;

//		if (Input.GetKey ("w")) {
//			transform.position += Vector3.up * speed * runSpeed * Time.deltaTime;
//		}
//		if (Input.GetKey("a")) {
//			transform.position += Vector3.left * speed * runSpeed * Time.deltaTime;
//		}
//		if (Input.GetKey ("s")) {
//			transform.position += Vector3.down * speed * runSpeed * Time.deltaTime;
//		}
//		if (Input.GetKey ("d")) {
//			transform.position += Vector3.right * speed * runSpeed * Time.deltaTime;
//		}
//		isWalking = Input.GetKey ("d") || Input.GetKey ("a") || Input.GetKey ("s") || Input.GetKey ("w");

//		if (isWalking && !soundPlaying) {
//			playWalkingSound ();
//		}
//		else if (!isWalking) {
//			SoundManager.instance.efxSource.Stop ();
//			soundPlaying = false;
//		}
		
//		if (Input.GetKeyDown (KeyCode.Space)) {
//			if (flashlight) {
//				lightOn = !lightOn;
//				flashlight.GetComponent<Renderer>().gameObject.SetActive(lightOn);
//			}
//		}

//		if (Input.GetKey (KeyCode.LeftShift)) {
//			runSpeed = runSpeedMultiplier;
//		} else {
//			runSpeed = 1;
//		}

//		Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint (Input.mousePosition + Vector3.forward * 10f);
//		float angle = AngleBetweenPoints (transform.position, mouseWorldPosition) + 180;
//		transform.rotation = Quaternion.Euler (new Vector3 (0f, 0f, angle));
//		print(angle);
//		if (angle >= 90 && angle < 225)
//			transform.localRotation = Quaternion.Euler(0, 180, 0);	
//		else
//			transform.localRotation = Quaternion.Euler(0, 0, 0);		

//		Vector3 theScale = transform.localScale;
//		if (angle >= 90 && angle < 270)
//			theScale.x = -1;
//		else
//			theScale.x = 1;
//		transform.localScale = theScale;
	}

	float AngleBetweenPoints (Vector2 a, Vector2 b) {
		return Mathf.Atan2(a.y - b.y, a.x - b.x) * Mathf.Rad2Deg;
	}

	void OnCollisionEnter2D(Collision2D coll) {
//		print ("collided");
//		if (coll.gameObject.tag == "Enemy")
//			print ("what");

	}

	void OnTriggerEnter2D(Collider2D other) {
//		if (other.gameObject.tag == "Enemy")
//			print ("what");
	}

	void playWalkingSound() {
		SoundManager.instance.PlaySingle (moveSound);
		soundPlaying = true;
	}
}
