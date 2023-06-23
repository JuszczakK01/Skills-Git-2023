using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour {
	public string direction;
	public float movementSpeed;
	// Use this for initialization
	void Start () {
		direction = "right";
		movementSpeed = 5f;
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
	}
	private void OnTriggerEnter2D(Collider2D other) {
		if (other.gameObject.tag == "leftMarker") {
			direction = "right";
		}
		else  if (other.gameObject.tag == "rightMarker") {
			direction = "left";
		}
	}
}
