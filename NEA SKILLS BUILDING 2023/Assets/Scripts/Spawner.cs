using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public GameObject Alter;
	public bool Spawned;
	public Vector3 SpawnedPosition;
	// Use this for initialization
	void Start () {
		Spawned = false;
		SpawnedPosition = new Vector3 (20.40648f, -1.175821f, 0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void SpawnAlter()
	{
		if (Spawned == false) {
			Instantiate (Alter, SpawnedPosition, Quaternion.identity);
			Spawned = true;
			Debug.Log ("Alter Spawned");
		}
	}
}
