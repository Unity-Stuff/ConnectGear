using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class LevelNameSetter : MonoBehaviour {

	// Use this for initialization
	Text levelName;
	void Start () {
		levelName=gameObject.GetComponent<Text>();
		levelName.text=SceneManager.GetActiveScene().name;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
