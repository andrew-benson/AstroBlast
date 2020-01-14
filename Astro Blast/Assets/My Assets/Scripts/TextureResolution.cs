using UnityEngine;
using System.Collections;

public class TextureResolution : MonoBehaviour
{
	static public bool debugMode = true; //used for setting variables at runtime (Update) - not optimized
	private GUITexture myGUITexture;
	public float xPos = 0.3f, yPos = -0.25f;
	public float width = 0.5f, height = 0.5f; 
	
	
	// Position the billboard in the center,
	// but respect the picture aspect ratio
	
	int textureHeight;
	int textureWidth;
	int screenHeight = Screen.height;
	int screenWidth = Screen.width;
	int screenAspectRatio;
	int textureAspectRatio;
	int scaledHeight;
	int scaledWidth;
	
	void Awake ()
	{
		myGUITexture = this.gameObject.GetComponent ("GUITexture") as GUITexture;
	}
     
	// Use this for initialization
	void Start ()
	{
		
		textureHeight = guiTexture.texture.height;
		textureWidth = guiTexture.texture.width;
		screenAspectRatio = (screenWidth / screenHeight);
		textureAspectRatio = (textureWidth / textureHeight);
			
		if (textureAspectRatio <= screenAspectRatio) {
			// The scaled size is based on the height
			scaledHeight = screenHeight;
			scaledWidth = (screenHeight * textureAspectRatio);
		} else {
			// The scaled size is based on the width
			scaledWidth = screenWidth;
			scaledHeight = (scaledWidth / textureAspectRatio);
		}
		if (!debugMode) {
			float xPosition = screenWidth * xPos - (scaledWidth / 2);
			myGUITexture.pixelInset = new Rect (xPosition, scaledHeight * yPos, scaledWidth * width, scaledHeight * height);
		}
	}
	
	void Update ()
	{
		if (debugMode) {
			float xPosition = screenWidth * xPos - (scaledWidth / 2);
			myGUITexture.pixelInset = new Rect (xPosition, scaledHeight * yPos, scaledWidth * width, scaledHeight * height);
		}
	}
}
