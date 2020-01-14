using UnityEngine;
using System.Collections;

public class Flash_Texture : MonoBehaviour
{
	public Texture texture1, texture2;
	public float delay = 1f;
	private float cachedDelay;
	// Use this for initialization
	void Start ()
	{
		cachedDelay = delay;
	}
	
	// Update is called once per frame
	void Update ()
	{
		
		if (guiTexture.enabled == true) {
			delay -= Time.deltaTime;
			
			if (delay < 0) {
				ChangeMaterial ();				
			}	
		}
	}
	
	void ChangeMaterial ()
	{
		
		if (guiTexture.texture == texture1) {
			guiTexture.texture = texture2;
			delay = cachedDelay;
		} else {
			guiTexture.texture = texture1;
			delay = cachedDelay;
		}

	}	
}
