using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroMovement : MonoBehaviour {
	Rigidbody2D rb;
	float speed;
	// Use this for initialization
	void Start () {
		speed = 8.1f;
		rb = GetComponent<Rigidbody2D> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey (KeyCode.LeftArrow)) {
			transform.Translate (Input.GetAxis ("Horizontal") * Time.deltaTime * speed, 0, 0);
		}
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			rb.AddForce (Vector2.up * 300);
		}
	}
	void resetPosition(){
		Debug.Log ("SPIKED RECEIVED!");
		transform.SetPositionAndRotation( new Vector3 (-5.62f, 0.78f, 0), Quaternion.identity);
	}
}
