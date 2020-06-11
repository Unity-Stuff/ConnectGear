using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HardwareButtonManagerScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape)) {
			
			if(SceneManager.GetActiveScene().name=="MainMenu")
		 		Application.Quit();
			else if(SceneManager.GetActiveScene().name=="BaseLevelMenu")
				SceneManager.LoadScene("MainMenu");
			else 
				SceneManager.LoadScene("BaseLevelMenu");

		 	}
	}

}
