using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BufferScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if(PlayerPrefs.GetInt("LoadTutorial")==-1)
			SceneManager.LoadScene("MainMenu");
		else
			SceneManager.LoadScene("Tutorial");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
