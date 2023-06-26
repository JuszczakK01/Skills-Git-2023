using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

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
		Debug.Log ("The sign has felt your presence!");
		signText.text = "The sign has felt your presence!";
	}
	private void OnTriggerExit2D(Collider2D other){
		Debug.Log ("The sign can no longer feel your presence! Come back!");
		signText.text = "The sign can no longer feel your presence! Come back!";
	}
	private void OnTriggerStay2D(Collider2D other){
		Debug.Log ("Why are you still here? Go away!");
	}
}
