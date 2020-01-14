using UnityEngine;
using System.Collections;

public class CreateAsteroid : MonoBehaviour {
	//Load starting asteroids
	void Update(){
		 

	}
	void Start(){
		
	}
	void Awake(){
    	StartCoroutine(LoadTheAsteroids());
			
	}
	
	IEnumerator LoadTheAsteroids(){
	    yield return new WaitForSeconds(1f);

		int i = 0;
		while (i < 7) {
		Instantiate(Resources.Load("Small_Asteroid")); 
		i++;
		}		
		
		int j = 0;
		while (j < 5) {
			Instantiate(Resources.Load("Medium_Asteroid")); 
			j++;
		}
		
		int k = 0;
		while (k < 3) {
			Instantiate(Resources.Load("Large_Asteroid")); 
			k++;
		}
	}
}
