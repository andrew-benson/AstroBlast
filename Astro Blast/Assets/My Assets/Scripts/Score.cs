using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour
{
	public float score, highscore = 0;
	public float scoreMultiplier = 100;
	public int mineralCount;
	public bool gameover;
	private bool submitted = false;
	Rect windowRect = new Rect (Screen.width * .3f, Screen.height * .3f, Screen.width * .3f, Screen.height * .7f);
	public GUIStyle myStyle, scoreStyle;
	string stringToEdit = "anonymous";
	HSController highScoreScript;
	bool isHarder = false;
	
	void Start ()
	{
		highScoreScript = GetComponent<HSController> ();
	}
	
	void Update ()
	{
		//Update score
		score += Time.deltaTime * scoreMultiplier;
		
		if(!isHarder){ 
			if(score > 2000f){
				isHarder = true;
			}
		}
		
		/*
		//casting causes errors so round the score first
		//cast to int for switch 
		if ((int)score % 700 == 0) {
			Instantiate (Resources.Load ("Defence_Perk"));
			Instantiate (Resources.Load ("Spray_Bullet_Perk"));
		}

		if ((int)score % 1000 == 0) {
			Instantiate (Resources.Load ("Small_Asteroid"));
			Instantiate (Resources.Load ("Defence_Perk"));
		}
	
		if ((int)score % 1800 == 0) {
			Instantiate (Resources.Load ("Medium_Asteroid")); 
		}
		
		if ((int)score % 2001 == 0) {
			Instantiate (Resources.Load ("Large_Asteroid")); 
		}*/
	}
	
	public void GameOver ()
	{
		gameover = true;
		
		//store the last game score
		PlayerPrefs.SetInt ("CurrentScore", (int)Mathf.Round (score));
		
		//if the new score is greater than the highest score: set new score
		if (score > PlayerPrefs.GetInt ("HighScore")) {
			PlayerPrefs.SetInt ("HighScore", (int)Mathf.Round (score));
		}
		
	}
	
	
		
	IEnumerator Submitted ()
	{
		yield return new WaitForSeconds(2.0f);
		Application.LoadLevel (3);
	}
	

	void OnGUI ()
	{
		
		GameObject shipInfo = GameObject.Find ("MonkeyShip");
		GameObject cameraInfo = GameObject.Find ("Main Camera");	
		//GUI.Label (new Rect (0, 20, 150, 100), "Screen DPI: " + Screen.dpi);
		scoreStyle.fontSize = (int)(Screen.width*0.03);
		GUI.Label (new Rect (Screen.width * 0.4f, Screen.height * 0.05f, Screen.width*0.3f, Screen.height * 0.4f), "Score: " + (int)Mathf.Round (score), scoreStyle);

		// Show game over menu
	
		// Submit highscore via return key on keyboard
		Event e = Event.current;
		if (e.keyCode == KeyCode.Return && submitted == false) {
			gameover = false;
			highScoreScript.StartCoroutine (highScoreScript.PostScores (stringToEdit, (int)Mathf.Round (score)));
			submitted = true;
			Debug.Log ("You have successfully submitted name: " + stringToEdit + " Score: " + (int)Mathf.Round (score));
			StartCoroutine ("Submitted");
		}
	}
}
