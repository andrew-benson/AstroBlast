using UnityEngine;
using System.Collections;

public class GUI_Script : MonoBehaviour
{
	public GUITexture start, instructions;
	//credits = null, quit = null, highscore = null;
	SceneFadeInOut fadeScript;
	
	
	void Start(){
		fadeScript = GetComponent<SceneFadeInOut>();
	}
	// Update is called once per frame
	void Update ()
	{ 
		int fingerCount = 0;
		
		foreach (Touch touch in Input.touches) {
			if (touch.phase == TouchPhase.Began && start.HitTest (touch.position)) {
				fadeScript.StopClearing();
				fadeScript.EndScene();
			} 
		}
		
		if (start.HitTest (Input.mousePosition, Camera.main)) {
			fadeScript.StopClearing();

			fadeScript.EndScene();
		} 
			
	   
		if (fingerCount > 0) {
			print ("User has " + fingerCount + " finger(s) touching the screen");
		}
		
		if (Input.GetKey (KeyCode.Space))
			Application.LoadLevel (1);
	
		if (Input.GetKey (KeyCode.Escape))
			Application.Quit ();

	}

}