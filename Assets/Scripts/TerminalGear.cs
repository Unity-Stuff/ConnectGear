using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class TerminalGear : MonoBehaviour {

	// Use this for initialization
	LineDemo lineDemo;
	GameObject[] gearsList;
	int levelCompleted;
	bool soundFlag;
	void Start () {
		soundFlag=true;
		levelCompleted=1;
		lineDemo=gameObject.GetComponent<LineDemo>();
		gearsList=GameObject.FindGameObjectsWithTag("Gear");
	}
	
	// Update is called once per frame
	void Update () {
		if(lineDemo.countInLines==lineDemo.maxInLines){
			levelCompleted=1;
			CheckLevelCompletion();
		}
	}
	void CheckLevelCompletion(){
		lineDemo.countOutLines=1; //to ensure that outgoing lines could not be drawn
			foreach(GameObject gear in gearsList){
				LineDemo lineDemoChild=gear.GetComponent<LineDemo>();
				if(lineDemoChild.countInLines!=lineDemoChild.maxInLines || lineDemoChild.countOutLines!=lineDemoChild.maxOutLines){
					levelCompleted=0;
				}
			}
			if(levelCompleted==1){
				if(soundFlag==true){ //ensures sound is played only once and not on every update
					ButtonSoundPlayer.instance.PlayLvlCompClip();
					soundFlag=false;
					}

				int currentUnlockedLvl=PlayerPrefs.GetInt("LvlUnlocked");
				int lvlUnlockedCount=PlayerPrefs.GetInt("LvlUnlockedCount");
				string currentScene=SceneManager.GetActiveScene().name;

//				string []lvlUnlockedArr;
				List<string> lvlUnlockedArr=new List<string>();
				for(int i=0;i<lvlUnlockedCount;i++){
					lvlUnlockedArr.Add(PlayerPrefs.GetString("LvlUnlockedArr"+i));
				}

				if(lvlUnlockedArr.Contains(currentScene)==false){
	//				PlayerPrefs.SetInt("LvlUnlockedCount", ++lvlUnlockedCount);
					PlayerPrefs.SetInt("LvlUnlocked",++currentUnlockedLvl);
					PlayerPrefs.SetString("LvlUnlockedArr"+lvlUnlockedCount,currentScene);
					PlayerPrefs.SetInt("LvlUnlockedCount",++lvlUnlockedCount);
					if(currentUnlockedLvl%20==0){
						int currentWorldUnlocked=PlayerPrefs.GetInt("WorldUnlocked");
						PlayerPrefs.SetInt("WorldUnlocked",++currentWorldUnlocked);
					}
				}

				IEnumerator coroutine=LoadNextLevel();
				StartCoroutine(coroutine);

				
			}
	}
	IEnumerator LoadNextLevel(){
		yield return new WaitForSeconds(1);
		int nextLevelIndex=SceneManager.GetActiveScene().buildIndex+1;
		fadeScript.instance.FadeLevelLoader(nextLevelIndex.ToString());
	}
}
