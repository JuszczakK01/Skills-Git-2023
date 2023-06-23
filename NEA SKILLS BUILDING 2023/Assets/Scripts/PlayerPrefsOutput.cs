using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
public class PlayerPrefsOutput : MonoBehaviour {
	public TextMeshPro TxtOutput;
	// Use this for initialization
	void Start () {
		TxtOutput.text = PlayerPrefs.GetString ("WhichButtonClicked");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void NavButtonClicked () {
		SceneManager.LoadScene("Navigation");
	}
}
