using UnityEngine;
using System.Collections;

public class touch : MonoBehaviour
{
	public GameObject targetItem;
	
//Dragging limits
	float horizontalLimit, verticalLimit;
	public float sensitivity;
	float scroll;
	float deltaX, deltaY;
	float zpos;
	float scrollDistanceX;
	float scrollDistanceY;
	RaycastHit hit;
	LayerMask layerMask = (1 << 8) | (1 << 2);
	bool fire;
	public bool sprayBulletPerk;
	bool unbalanced;
	bool changed = false;
	public bool lightspeed = false;
	float rotationSpeed = 200f;
	int dir = 1;
	Asteroid_Move asteroidScript;
	static int i = 0;
	void Start ()
	{

		sensitivity = 1f - (Screen.dpi / 600f); 
		//horizontalLimit = 1f - Screen.dpi / 500f;//1-160/500 = 0.68 
		//verticalLimit = 1f- Screen.dpi / 320f; //1-160/320 = 0.5
		
		horizontalLimit = 1f;
		verticalLimit = 0.5f;
		scrollDistanceX = targetItem.transform.position.x;
		scrollDistanceY = targetItem.transform.position.y;
		layerMask = ~ layerMask;

	}

	void Update ()
	{	 			
		unbalanced = (transform.rotation.z > 0.05f || transform.rotation.z < -0.05f);
		
		if (Input.GetKey (KeyCode.P)) {
			Asteroid_Move.motor = 0;
		}
	}
	
	IEnumerator RandomRotChange (float coolDown)
	{
		if (dir == 1)
			dir = -1;
		else
			dir = 1;
		//Debug.Log("Changed the direction");
		yield return new WaitForSeconds(coolDown);
		changed = false;
		
	}

	// Update is called once per frame
	void FixedUpdate ()
	{
	
		if (Input.touchCount > 0) {		//	If there are touches...
			Touch theTouch = Input.GetTouch (0);		//	Cache Touch (0)
			Ray ray = Camera.main.ScreenPointToRay (theTouch.position);
			float minX = -0.5f;
			float maxX = 0.5f;
			float minY = -0.31f;
			float maxY = 0.31f;
			
			
			if (changed == false) {
				StartCoroutine (RandomRotChange (Random.Range (5f, 10f)));			
				changed = true;
			}
			
			if (Physics.Raycast (ray, out hit, 50.0f, layerMask)) {			
         			
				if (Input.touchCount == 1) {
					fire = false;
							
					deltaX = theTouch.deltaPosition.x;
					deltaY = theTouch.deltaPosition.y;

							
					scrollDistanceX = Mathf.Clamp (scrollDistanceX + deltaX * 0.1f * Time.deltaTime, -horizontalLimit, horizontalLimit);
					scrollDistanceY = Mathf.Clamp (scrollDistanceY + deltaY * 0.1f * Time.deltaTime, -verticalLimit, verticalLimit);
							
					transform.position = new Vector3 (scrollDistanceX, scrollDistanceY, transform.position.z);
					transform.Rotate (0f, 0f, rotationSpeed * dir * deltaX * Time.deltaTime);

				}

				if (Input.touchCount > 1) {
							
					deltaX = theTouch.deltaPosition.x;
					deltaY = theTouch.deltaPosition.y;
					scrollDistanceX = Mathf.Clamp (scrollDistanceX + deltaX * Time.deltaTime * 0.5f, -horizontalLimit, horizontalLimit);
					scrollDistanceY = Mathf.Clamp (scrollDistanceY + deltaY * Time.deltaTime * 0.5f, -verticalLimit, verticalLimit);
					transform.position = new Vector3 (scrollDistanceX, scrollDistanceY, transform.position.z);
					      
					if (lightspeed == false) {
						if (!fire) {
							if (sprayBulletPerk){
								Instantiate(Resources.Load ("Spray_Bullet"), new Vector3 (transform.position.x, transform.position.y, transform.position.z + .5f), transform.rotation);
							}else{
								Instantiate (Resources.Load ("Bullet"), new Vector3 (transform.position.x, transform.position.y, transform.position.z + .5f), new Quaternion (0.0f, 90.0f, 90.0f, 0.0f)); 
								fire = true;
						
							}
						}
					}
				}			
		
			}
		} else if (Input.touchCount == 0) {
			if (unbalanced) {
				Debug.Log ("Ship is unbalanced");
				if (transform.eulerAngles.z > 180f) { 
					transform.Rotate (0f, 0f, 200f * Time.deltaTime);
				} else {
					transform.Rotate (0f, 0f, -200f * Time.deltaTime);
				}
			}
		}	
	}
	
	void OnGUI ()
	{
		GUI.Label (new Rect (0, 60, 150, 100), "Scroll Delta X: " + deltaX);
		GUI.Label (new Rect (0, 70, 150, 100), "Scroll Delta Y: " + deltaY);
		GUI.Label (new Rect (0, 80, 300, 100), "Scroll Distance X: " + scrollDistanceX);	
		GUI.Label (new Rect (0, 90, 300, 100), "Scroll Distance Y: " + scrollDistanceY);
		GUI.Label (new Rect (700, 20, 150, 100), "Ship Info" + "\n" + 
											 "Position X: " + transform.position.x + "\n" + 
											 "Position Y: " + transform.position.y + "\n" +
											 "Position Z: " + transform.position.z);
		GUI.Label (new Rect (900, 20, 150, 100), "Rotation X: " + transform.rotation.x + "\n" + 
											 "Rotation Y: " + transform.rotation.y + "\n" +
											 "Rotation Z: " + transform.rotation.z);
	}
}
