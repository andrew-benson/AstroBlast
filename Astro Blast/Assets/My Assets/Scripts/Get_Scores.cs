using UnityEngine;
using System.Collections;

public class Get_Scores : MonoBehaviour {

	string scoresURL = "http://astroblast.net78.net/display_scores.php";

	// Use this for initialization
	void Start () {
	        
		StartCoroutine(GetScores());

	}
	
	// Update is called once per frame
	IEnumerator GetScores()
    {
		
        WWW scores_get = new WWW(scoresURL);
        yield return scores_get;
 	    
        if (scores_get.error != null)
        {
            print("There was an error getting the high score: " + scores_get.error);
        }
        else
        {
            gameObject.guiText.text = scores_get.text; // this is a GUIText that will display the scores in game.
        }
		
    }

}
