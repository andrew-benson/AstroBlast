using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

	float velocity = 10f;
	float zpos;
	
	
	void Update () {
	
	//transform.position = new Vector3(transform.position.x, transform.position.y, zpos);
	transform.Translate(Vector3.up * velocity * Time.deltaTime);
	//Kill the bullet after 1.5 seconds	
	Destroy(gameObject, 1.25f);
	}
	
	void OnCollisionEnter(Collision collision) {
		Destroy(gameObject);
	}
}
