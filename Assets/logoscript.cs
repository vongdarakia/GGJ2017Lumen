using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoScript : MonoBehaviour {
	float time;
	public Image myImage;
	Color fadeColor;

	// Use this for initialization
	void Start () {
		time = 3.0f;
		fadeColor = new Color (1f, 1f, 1f, 0f);
		myImage.CrossFadeColor (fadeColor, time, true, true);

	}
}