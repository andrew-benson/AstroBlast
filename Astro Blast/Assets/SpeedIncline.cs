using UnityEngine;
using System.Collections;

public class SpeedIncline : MonoBehaviour {
	float timer = 1f;
	public float shipVelocity; //Debug the velocity
	
	// Use this for initialization
	void Start () {
	Asteroid_Move.shipVelocity = 0.7f;
	}
	
	// Update is called once per frame
	void Update () {
		
		timer -= Time.deltaTime;
		
		//every second, increase the velocity of the asteroids
		if(timer < 0){
			if(Asteroid_Move.shipVelocity < 2f){
				Asteroid_Move.shipVelocity += 0.04f;	
				shipVelocity = Asteroid_Move.shipVelocity;
			}
			timer = 1f;
		}
		
		
		
	}
}
