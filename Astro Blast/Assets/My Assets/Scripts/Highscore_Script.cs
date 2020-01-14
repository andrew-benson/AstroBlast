using UnityEngine;
using System.Collections;

public class Highscore_Script : MonoBehaviour {
	public GUIStyle scoreStyle;
	
	
	// Update is called once per frame
	void Update () {
		
		Score scoreScript = GetComponent<Score>();
		
			//guiText.text = "Top Score: " + PlayerPrefs.GetInt("HighScore").ToString()+"\n"+
	}
	
	void OnGUI(){

		GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.9f, 150, 100), "Top Score: " + PlayerPrefs.GetInt("HighScore").ToString(),scoreStyle);
		GUI.Label(new Rect(Screen.width * 0.1f, Screen.height * 0.8f,150,100), "Your Score: " + PlayerPrefs.GetInt("CurrentScore").ToString(),scoreStyle);

	}
}
