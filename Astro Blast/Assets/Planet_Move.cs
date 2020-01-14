using UnityEngine;
using System.Collections;

public class Planet_Move : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.Rotate(new Vector3(0f,-0.5f * Time.deltaTime,0f));
		transform.Translate(Vector3.back * 0.1f * Time.deltaTime);
	}
}
