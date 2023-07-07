using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public string direction;
	public float movementSpeed;
	GameObject Hero;
	bool invincible;
	bool tempinv;
	// Use this for initialization
	void Start () {
		direction = "right";
		movementSpeed = 5f;
		Hero = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (direction == "right")
		{
			transform.Translate(Vector3.right * Time.deltaTime * movementSpeed);
		}
		else if (direction == "left")
		{
			transform.Translate(Vector3.left * Time.deltaTime * movementSpeed);
		}
		invincible = Hero.GetComponent<HeroMovement>().invincible;
		tempinv = Hero.GetComponent<HeroMovement>().temporaryinv;
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "leftMarker") {
			direction = "right";
		}
		else  if (other.gameObject.tag == "rightMarker") {
			direction = "left";
		}
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if ((invincible == false && tempinv == false) && other.gameObject.tag == "Player") {
			Debug.Log ("HIT!");
			Hero.SendMessage("resetPosition");
		}
	}
	private void OnCollisionStay2D(Collision2D other){
		if ((invincible == false && tempinv == false) && other.gameObject.tag == "Player") {
			Debug.Log ("HIT!");
			Hero.SendMessage ("resetPosition");
		}
	}

}
