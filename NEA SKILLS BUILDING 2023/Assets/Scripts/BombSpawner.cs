using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombSpawner : MonoBehaviour {
	public GameObject bomb;
	// Use this for initialization
	void Start () {
		InvokeRepeating ("Spawner", 2, 2);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void Spawner (){
		Instantiate (bomb, new Vector3 (26, 7, 0), Quaternion.identity);
	}
	void InvokeRepeating(){
		Instantiate (bomb, new Vector3 (26.5289f, 6.874392f, 0), Quaternion.identity);
	}
}
