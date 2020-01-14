using UnityEngine;
using System.Collections;

public class TransparentAsteroid : MonoBehaviour {
	public static bool isTransparent;
	GameObject trigger;
	// Use this for initialization
	void Start () {
		trigger = GameObject.Find("Transparent Trigger");
		isTransparent = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {
		
		// Define box for non transparent area using position values
		//isTransparent = !(transform.position.x < 0.35f && transform.position.x > -0.35f  	&& transform.position.y < 0.35f && transform.position.y > -0.35f );
		
		// if outside the box, turn the collider on
		/*
		if(isTransparent){
			trigger.collider.enabled = true;
		}else{
			trigger.collider.enabled = false;
		}*/
	}
}
