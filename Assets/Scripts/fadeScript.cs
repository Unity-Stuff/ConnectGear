using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class fadeScript : MonoBehaviour {


	public static fadeScript instance;
	string nextSceneName;
	void Start(){
		instance=this;

	}
	public void FadeLevelLoader(string nextSceneName){
		this.nextSceneName=nextSceneName;
		IEnumerator coroutine=FadeDelayer();
		StartCoroutine(coroutine);
	}
	IEnumerator FadeDelayer()
	{
		yield return new WaitForSeconds(0.1f);
		Initiate.Fade(nextSceneName,Color.black,1f);
	}
	// Update is called once per frame
	void Update () {
		
	}
}
