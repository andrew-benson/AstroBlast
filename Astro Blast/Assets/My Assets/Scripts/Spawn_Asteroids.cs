using UnityEngine;
using System.Collections;

public class Spawn_Asteroids : MonoBehaviour {
	
	float asteroidTimer = 5f;
	int addedAsteroids = 0;
	public int maxNoOfAsteroids = 20;
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		if(addedAsteroids < maxNoOfAsteroids){
			asteroidTimer -= Time.deltaTime;	
		}
		
		if(asteroidTimer < 0){
			int randomNum = Random.Range(0,3);
			addedAsteroids++;
			Debug.Log("Random Number Generator : " + randomNum.ToString());
			Debug.Log("Number of Additional Asteroids : " + addedAsteroids.ToString());

			switch(randomNum){
			case 0:
				Instantiate (Resources.Load ("Small_Asteroid"));
				asteroidTimer = 5f;
				break;
			case 1:
				Instantiate (Resources.Load ("Medium_Asteroid")); 
				asteroidTimer = 5f;
				break;
			case 2:
				Instantiate (Resources.Load ("Large_Asteroid")); 
				asteroidTimer = 5f;
				break;
			default:
				asteroidTimer = 5f;
				break;
			}
		}
		
	}
}
