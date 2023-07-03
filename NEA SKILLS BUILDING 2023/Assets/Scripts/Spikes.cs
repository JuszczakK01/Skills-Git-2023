using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {
	GameObject Hero;
	bool invincible;
	// Use this for initialization
	void Start () {
		Hero = GameObject.FindGameObjectWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		invincible = Hero.GetComponent<HeroMovement>().invincible;
	}
	private void OnCollisionEnter2D(Collision2D other) {
		if (invincible == false) {
			Debug.Log ("SPIKED!");
			Hero.SendMessage ("resetPosition");
		}
	}
	private void OnCollisionStay2D(Collision2D other){
		if (invincible == false) {
			Debug.Log ("SPIKED!");
			Hero.SendMessage ("resetPosition");
		}
	}
}

