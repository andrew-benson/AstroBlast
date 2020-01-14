using UnityEngine;
using System.Collections;

public class Spawn_PowerUps : MonoBehaviour {

	public float timer = 3f;
	int selector = 0;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		timer -= Time.deltaTime;
		
		if(timer < 0){
			selector = Random.Range(0,4);
			
			switch(selector){
			case 0:
				Instantiate (Resources.Load ("Spray_Bullet_Perk"));
				break;
			case 1:
				Instantiate (Resources.Load ("Defence_Perk"));
				break;
			case 2:
								Instantiate (Resources.Load ("SlowMo_Perk"));

				//Instantiate (Resources.Load ("TwoShot_Bullet_Perk"));
				break;
			case 3:
				Instantiate (Resources.Load ("SlowMo_Perk"));
				break;
			}
			timer = 3f;
			
		}
	}
}
