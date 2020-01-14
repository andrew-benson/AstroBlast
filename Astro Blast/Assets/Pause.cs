using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {

	bool isPaused = false;
	RaycastHit hit;
	public Transform player;
	TouchInput touchScript;
	LaserPointer pointerScript;
	
	// Use this for initialization
	void Start () {
			touchScript = player.gameObject.GetComponent<TouchInput>();
			pointerScript = player.gameObject.GetComponent<LaserPointer>();

	}
	
	// Update is called once per frame
	void Update () {
	Touch theTouch = Input.GetTouch (0);
		Ray ray = Camera.main.ScreenPointToRay (theTouch.position);
		
		if (Physics.Raycast (ray, out hit, 50.0f)) {
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began) {
				if (hit.collider.name == "Pause") {
					if (isPaused) {
						touchScript.enabled = true;
						pointerScript.enabled = true;
						Time.timeScale = 1;
						isPaused = false;
					} else {
						isPaused = true;
						Time.timeScale = 0;
						touchScript.enabled = false;
						pointerScript.enabled = false;
					}
				}
			}
	}
	}
}
