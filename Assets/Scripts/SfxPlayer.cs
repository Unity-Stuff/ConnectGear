using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SfxPlayer : MonoBehaviour {

	// Use this for initialization
	public AudioClip clip;
	void Start () {
		SoundManager.instance.RandomizeSfx(clip);
		IEnumerator coroutine=DestroyExplosionObject();
		StartCoroutine(coroutine);
	}
	IEnumerator DestroyExplosionObject(){
		yield return new WaitForSeconds(2);
		DestroyObject(gameObject);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
