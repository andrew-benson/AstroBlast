using UnityEngine;
using System.Collections;

public class Block_Script : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnCollisionEnter(Collision other){
		if(gameObject.collider.enabled){
			
	
			if(other.gameObject.layer == 8)
			other.gameObject.GetComponent<Asteroid_Move>().Reset();	
			
		
			if(other.gameObject.layer == 9)
			Destroy(other.gameObject);
			
			if(other.gameObject.tag == "Bullet")
			Destroy(other.gameObject);
		}
	}
}
