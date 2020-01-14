using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TransparentMaterial : MonoBehaviour
{
	
	public Material small, medium, large;
	public Material defaultSmall, defaultMedium, defaultLarge;
	
	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}
	
	void OnTriggerEnter (Collider other)
	{
		if (TransparentAsteroid.isTransparent) {
			if (other.name == "Small_Asteroid(Clone)") {
				other.renderer.material = small;	
			} else if (other.name == "Medium_Asteroid(Clone)") {
				other.renderer.material = medium;	
			} else if (other.name == "Large_Asteroid(Clone)") {
				other.renderer.material = large;	
			}
		}
	}
	
	void OnTriggerExit (Collider other)
	{	
		if (other.name == "Small_Asteroid(Clone)") {
			other.renderer.material = defaultSmall;	
		} else if (other.name == "Medium_Asteroid(Clone)") {
			other.renderer.material = defaultMedium;	
		} else if (other.name == "Large_Asteroid(Clone)") {
			other.renderer.material = defaultLarge;	
		}
	}
	
	void OnTriggerStay (Collider other)
	{
		if (TransparentAsteroid.isTransparent) {
			if (other.name == "Small_Asteroid(Clone)") {
				other.renderer.material = small;	
			} else if (other.name == "Medium_Asteroid(Clone)") {
				other.renderer.material = medium;	
			} else if (other.name == "Large_Asteroid(Clone)") {
				other.renderer.material = large;	
			}
		} else {
			//  Debug.Log ("change to default");
			if (other.name == "Small_Asteroid(Clone)") {
				other.renderer.material = defaultSmall;	
			} else if (other.name == "Medium_Asteroid(Clone)") {
				other.renderer.material = defaultMedium;	
			} else if (other.name == "Large_Asteroid(Clone)") {
				other.renderer.material = defaultLarge;	
			}
		}
	}
	
	// collider is switched off, triggerExit cannot switch materials back to default 
	// TriggerExit && collider.enabled == false
	void OnDisable ()
	{
		
	
	}
	
}
