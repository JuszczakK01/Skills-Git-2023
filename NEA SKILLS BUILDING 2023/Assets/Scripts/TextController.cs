using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextController : MonoBehaviour {
	public TextMeshPro gemCounter;
	GameObject [] totalGems;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		totalGems = GameObject.FindGameObjectsWithTag ("redGem");
		gemCounter.text = "Gems: " + totalGems.Length.ToString ();
	}
}
