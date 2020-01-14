using UnityEngine;
using System.Collections;

public class Splash_Screen : MonoBehaviour {
	public float timeDisplayed = 2.0f;
		
	// Use this for initialization
	void Start () {
		StartCoroutine("DisplaySplash");

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	IEnumerator DisplaySplash(){
		yield return new WaitForSeconds(timeDisplayed);
		Application.LoadLevel(1);
	}
}
