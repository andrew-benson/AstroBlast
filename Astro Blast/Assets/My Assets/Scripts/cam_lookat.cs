using UnityEngine;
using System.Collections;

//Converted from SmoothLookAt.js
public class cam_lookat : MonoBehaviour {

	// Use this for initialization
public Transform target;
public float damping = 1.0f;
bool smooth = true;

void LateUpdate () {
	if (target) {
		if (smooth)
		{
			// Look at and dampen the rotation
			Quaternion rotation = Quaternion.LookRotation(target.position - transform.position);
			transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
		}
		else
		{
			// Just lookat
		    transform.LookAt(target);
		}
	}
}

void Start () {
	// Make the rigid body not change rotation
   	if (rigidbody) rigidbody.freezeRotation = true;
}
}
