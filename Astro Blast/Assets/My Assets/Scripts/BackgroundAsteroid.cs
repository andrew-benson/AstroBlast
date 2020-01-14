using UnityEngine;
using System.Collections;

public class BackgroundAsteroid : MonoBehaviour {
	float speed = 3f;
	Vector3 startPos;
	
	// Use this for initialization
	void Start () {
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.Translate(Vector3.back * speed * Time.deltaTime);
		
		if(transform.position.z < 0.7f){
			transform.position = startPos;
		}
	}
}
