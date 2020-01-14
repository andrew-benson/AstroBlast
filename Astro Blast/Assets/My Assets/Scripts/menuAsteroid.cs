using UnityEngine;
using System.Collections;

public class menuAsteroid : MonoBehaviour {
   private float xpos;

	// Use this for initialization
	void Start () {
	xpos = transform.position.x;
	}
	
	// Update is called once per frame
	void Update () {
    xpos += 0.3f * Time.deltaTime;
	transform.position = new Vector3 (xpos, transform.position.y,transform.position.z);
	}
}
