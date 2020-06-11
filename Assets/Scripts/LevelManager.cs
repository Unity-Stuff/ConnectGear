using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelManager : MonoBehaviour {

	// Use this for initialization

	void Start () {
		
		if(PlayerPrefs.GetInt("WorldUnlocked")==0){ //initializes on 1st game launch
			PlayerPrefs.SetInt("WorldUnlocked",1);
		}
		if(PlayerPrefs.GetInt("LvlUnlocked")==0){	//initializes on 1st game launch
			PlayerPrefs.SetInt("LvlUnlocked",1);
		}
		Debug.Log("LvlSlct:"+PlayerPrefs.GetInt("LvlUnlocked"));

		for(int i=1;i<=PlayerPrefs.GetInt("LvlUnlocked");i++){
			GameObject LvlIcon=GameObject.Find(i.ToString());
			if(LvlIcon){
				Button LvlButton=LvlIcon.GetComponent<Button>();
				LvlButton.interactable=true;
				ColorBlock cb=LvlButton.colors;
				if(i==PlayerPrefs.GetInt("LvlUnlocked"))
					cb.normalColor=Color.red;
				else
					cb.normalColor=Color.green;
				LvlButton.colors=cb;
			}
		}
		for(int i=1;i<=PlayerPrefs.GetInt("WorldUnlocked");i++){
			GameObject LvlIcon=GameObject.Find(i.ToString()+"w");
			if(LvlIcon){
				Button LvlButton=LvlIcon.GetComponent<Button>();
				LvlButton.interactable=true;
				ColorBlock cb=LvlButton.colors;
				LvlButton.colors=cb;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void LoadLevel(string loadLevel)
    {

		fadeScript.instance.FadeLevelLoader(loadLevel);

    }
}
