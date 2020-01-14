using UnityEngine;
using System.Collections;

public class Get_Names : MonoBehaviour { 
	string namesURL = "http://astroblast.net78.net/display_names.php";

	// Use this for initialization
	void Start () {
	        
		StartCoroutine(GetNames());

	}
	
	// Update is called once per frame
	IEnumerator GetNames()
    {
		
        gameObject.guiText.text = "Loading Scores";
        WWW name_get = new WWW(namesURL);
        yield return name_get;
 	    
        if (name_get.error != null)
        {
            print("There was an error getting the high score: " + name_get.error);
        }
        else
        {
            gameObject.guiText.text = name_get.text; // this is a GUIText that will display the scores in game.
        }
		
    }

}
