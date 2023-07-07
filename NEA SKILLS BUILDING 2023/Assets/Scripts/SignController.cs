using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SignController : MonoBehaviour {
	public TextMeshPro signText;
	// Use this for initialization
	void Start () {
		signText = GetComponentInChildren<TextMeshPro> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other){
		if (SceneManager.GetActiveScene ().name == "Level 3") {
			signText.text = "Press Left Shift key while moving left or right to dash! You can even dash through enemies!";
		} else {
			Debug.Log ("The sign has felt your presence!");
			signText.text = "The sign has felt your presence!";
		}
	}
	private void OnTriggerExit2D(Collider2D other){
		if (SceneManager.GetActiveScene ().name == "Enemy") {
			Debug.Log ("The sign can no longer feel your presence! Come back!");
			signText.text = "The sign can no longer feel your presence! Come back!";
		} else {
			signText.text = "";
		}
	}
	private void OnTriggerStay2D(Collider2D other){
		if (SceneManager.GetActiveScene ().name == "Enemy") {
			Debug.Log ("Why are you still here? Go away!");
		}
	}
}
