using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour {

	// Use this for initialization
	GameObject[] TutorialObjects;
	void Start () {
		
		TutorialObjects=GameObject.FindGameObjectsWithTag("TutorialObject");
		if(PlayerPrefs.GetInt("HighScore")!=0){
			foreach( GameObject g in TutorialObjects){
				g.SetActive(false);
			}
			}
		else{
			IEnumerator couroutine=ShowTutorial();
			StartCoroutine(couroutine);
		}
		}
	
	IEnumerator ShowTutorial(){
		yield return new WaitForSeconds(6);
			foreach( GameObject g in TutorialObjects){
				g.SetActive(false);
			}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
