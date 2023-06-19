using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Navigation : MonoBehaviour {
	private Canvas mainCanvas;
	public TextMeshPro timer;
	// Use this for initialization
	void Start () {
		mainCanvas = GameObject.FindObjectOfType<Canvas> ();
		mainCanvas.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
		timer.text = Time.fixedTime.ToString("0.00");
		if (Input.GetKey (KeyCode.Escape)) {
			mainCanvas.enabled = true;
			Time.timeScale = 0f;
		}
	}
	public void ClickedButtonA(){
		Debug.Log ("Button A Clicked");
	}

	public void ClickedButtonB(){
		Debug.Log ("Button B Clicked");
	}

	public void ClickedExit(){
		Debug.Log ("Exit Clicked");
		Time.timeScale = 1;
	}
}
