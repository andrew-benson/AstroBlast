using UnityEngine;
using System.Collections;

public class PlayerInfo : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI ()
	{
		
		GUI.Label (new Rect (700, 20, 150, 100), "Ship Info" + "\n" + 
											 "Position X: " + transform.position.x + "\n" + 
											 "Position Y: " + transform.position.y + "\n" +
											 "Position Z: " + transform.position.z);
		GUI.Label (new Rect (900, 20, 150, 100), "Rotation X: " + transform.rotation.x + "\n" + 
											 "Rotation Y: " + transform.rotation.y + "\n" +
											 "Rotation Z: " + transform.rotation.z);
	}
}
