using UnityEngine;
using System.Collections;

public class Shockwave : MonoBehaviour {
	float xScale, zScale;
	float step;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		step = 10f * Time.deltaTime;

		if(transform.localScale.x < 8f){
			gameObject.transform.localScale = Vector3.MoveTowards(transform.localScale, new Vector3(8f,transform.localScale.y,8f), step);
		} else {
			gameObject.SetActive(false);
			Invoke("TurnOffParticle", 2f);
		}
		//gameObject.transform.localScale += new Vector3(0.1f, 0.1f, 0.1f) * Time.deltaTime; 
	}

	void TurnOffParticle(){
		Destroy(gameObject.transform.parent.gameObject);
	}
}
