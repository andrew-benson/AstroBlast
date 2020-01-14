using UnityEngine;
using System.Collections;

public class GUI_Instructions : MonoBehaviour {
	public GUITexture back;
	public int level;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		foreach (Touch touch in Input.touches) {
            if (touch.phase == TouchPhase.Stationary && back.HitTest(touch.position)){
                Application.LoadLevel(level);
			}
		}

	}
}