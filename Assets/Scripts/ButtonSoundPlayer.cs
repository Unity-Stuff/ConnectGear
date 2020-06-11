using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonSoundPlayer : MonoBehaviour {

	// Use this for initialization
	public AudioClip clip;
	public AudioClip[] gearSounds;
	public AudioClip lvlCmpClip;
	int gearClipIndex;
	public GameObject SoundButton;
	public GameObject SoundOffButton;
	public GameObject MusicButton;
	public GameObject MusicOffButton;
	int soundState;
	int musicState;
	public static ButtonSoundPlayer instance;



	void Start () {
		instance=this;
		gearClipIndex=0;
		SoundButton=GameObject.Find("SoundButton");
		SoundOffButton=GameObject.Find("SoundOffButton");
		MusicButton=GameObject.Find("MusicButton");
		MusicOffButton=GameObject.Find("MusicOffButton");
		soundState=PlayerPrefs.GetInt("Sound");
		musicState=PlayerPrefs.GetInt("Music");
//		HideOffButtons();
		MuteOnState();
		UIManager.instance.hidePaused();
		}
	
	// Update is called once per frame
	void Update () {

	}

	public void PlayClip(){
		SoundManager.instance.RandomizeSfx(clip);
	}
	public void PlayGearClip(){
		if(gearClipIndex==10)
			gearClipIndex=0;
		SoundManager.instance.RandomizeSfx(gearSounds[gearClipIndex++]);
	}
	public void PlayLvlCompClip(){
		SoundManager.instance.RandomizeSfx(lvlCmpClip);
	}
	public void MuteMusic(){
        	SoundManager.instance.musicSource.volume=0;
        	PlayerPrefs.SetInt("Music",1);
			MusicOffButton.SetActive(true);
        	MusicButton.SetActive(false);

        }
       public void MuteSound(){
       		PlayerPrefs.SetInt("Sound", 1);
			SoundManager.instance.efxSource.volume=0;
			SoundButton.SetActive(false);
			SoundOffButton.SetActive(true);
        }
	public void UnMuteMusic(){
			PlayerPrefs.SetInt("Music", 0);
        	SoundManager.instance.musicSource.volume=0.75f;
        	MusicButton.SetActive(true);
        	MusicOffButton.SetActive(false);
        }
       public void UnMuteSound(){
       	PlayerPrefs.SetInt("Sound", 0);
		SoundManager.instance.efxSource.volume=1;
			SoundButton.SetActive(true);
			SoundOffButton.SetActive(false);
        }
        void MuteOnState(){
        	
			if(soundState==1){
				MuteSound();
        	}
        	if(musicState==1){
        		MuteMusic();
        	}
        	if(soundState==0){
				SoundOffButton.SetActive(false);
        	}
        	if(musicState==0){
				MusicOffButton.SetActive(false);
        	}
        }
}
