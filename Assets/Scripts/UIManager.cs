using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour {

	// Use this for initialization
	GameObject[] pauseObjects;
	GameObject[] finishObjects;
	GameObject[] headerObjects;
	public static UIManager instance;


	// Use this for initialization
	void Start () {
		instance=this;
		Time.timeScale = 1;

		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");			//gets all objects with tag ShowOnPause
		headerObjects=	GameObject.FindGameObjectsWithTag("Header");

//		hidePaused();


		}
	// Update is called once per frame
	void Update () {
		
		//uses the p button to pause and unpause the game
		if(Input.GetKeyDown(KeyCode.P))
		{
			if(Time.timeScale == 1 )
			{	
				hideHeader();
				Time.timeScale = 0;
				showPaused();

			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
				showHeader();
			}
		}

		//shows finish gameobjects if player is dead and timescale = 0
		if (Time.timeScale == 0){
	
			hideHeader();
		}
	}


	//Reloads the Level
	public void Reload(){
		Application.LoadLevel(Application.loadedLevel);
	}

	//controls the pausing of the scene
	public void pauseControl(){
			if(Time.timeScale == 1)
			{
				Time.timeScale = 0;
				showPaused();
			} else if (Time.timeScale == 0){
				Time.timeScale = 1;
				hidePaused();
			}
	}

	//shows objects with ShowOnPause tag
	public void showPaused(){
		foreach(GameObject g in pauseObjects){
			g.SetActive(true);
			}
		hideHeader();
	}

	//hides objects with ShowOnPause tag
	public void hidePaused(){
		pauseObjects = GameObject.FindGameObjectsWithTag("ShowOnPause");
		foreach(GameObject g in pauseObjects){
			g.SetActive(false);
		}

		showHeader();
	}


	public void showHeader(){
		foreach(GameObject g in headerObjects){
			g.SetActive(true);
		}
	}

	public void hideHeader(){
		foreach(GameObject g in headerObjects){
			g.SetActive(false);
		}
	}
	//loads inputted level
	public void LoadLevel(string level){
//		Initiate.Fade(level,Color.black,1f); //Calling fade into scene function
		Application.LoadLevel(level);
	}
}
