using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gears : MonoBehaviour {

	// Use this for initialization
	float rotationSpeed=10f;
	LineDemo lineDemo;
	Image image;
	public Sprite activeSprite;
	public Sprite inactiveSprite;
	void Start () {
		lineDemo=gameObject.GetComponent<LineDemo>();
		image=gameObject.GetComponent<Image>();
	}
	
	// Update is called once per frame
	void Update () {
	if(lineDemo.countInLines==lineDemo.maxInLines){
		transform.Rotate(0f,0f,-rotationSpeed*Time.deltaTime);
		image.sprite=activeSprite;
	}
	else{
		image.sprite=inactiveSprite;
	}
}
}