using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioClip coin;
	public AudioClip bomb;
	public AudioClip life;
	private AudioSource source;
	// Use this for initialization
	void Start () {
			source = GetComponent<AudioSource> ();	
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	private void OnTriggerEnter2D(Collider2D other){
		Debug.Log ("bing!");
		source.PlayOneShot (coin, 1);
	}
	public void OnCollisionEnter2D(Collision2D other){
		if (other.gameObject.tag == "extraLife") {
			source.PlayOneShot (life, 1);
		} else if (other.gameObject.tag == "vulnerable") {
			source.PlayOneShot (bomb, 1);
		}
	}
		
}
