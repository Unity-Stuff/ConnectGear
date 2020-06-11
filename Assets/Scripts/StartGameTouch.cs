using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class StartGameTouch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonUp(0)){
			ButtonSoundPlayer.instance.PlayLvlCompClip();
			LoadLevel();
		}
            
		
	}
	void LoadLevel()
    {
		int nextLevelIndex=SceneManager.GetActiveScene().buildIndex+1;
		fadeScript.instance.FadeLevelLoader(nextLevelIndex.ToString());
//		fadeScript.instance.FadeLevelLoader("BaseLevelMenu");

    }
}
