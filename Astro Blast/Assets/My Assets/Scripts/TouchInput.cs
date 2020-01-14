using UnityEngine;

using System.Collections;

public class TouchInput : MonoBehaviour
{
	
	[SerializeField]

	public float _horizontalLimit = 2.5f, _verticalLimit = 2.5f, dragSpeed = 0.01f;
	public float rotationSpeed = 200f;
	Transform cachedTransform;
	Vector3 startingPos;
	public bool lightspeed = false;
	public bool sprayBulletPerk = false;
	public bool dualBulletPerk = false;
	bool isChanged = false;
	bool unbalanced;
	int dir;
	RaycastHit hit;

	void Start ()
	{
		//Make reference to transform
		cachedTransform = transform;

		//Save starting position
		startingPos = cachedTransform.position;
	}
	
	void Update ()
	{
		unbalanced = (transform.rotation.z > 0.05f || transform.rotation.z < -0.05f);
		
		if (Input.touchCount > 0) {
			Vector2 deltaPosition = Input.GetTouch (0).deltaPosition;
			
			if (isChanged == false) {
				StartCoroutine (RandomRotChange (Random.Range (5f, 10f)));			
				isChanged = true;
			}
			
			//Switch through touch events
			switch (Input.GetTouch (0).phase) {
			case TouchPhase.Began:	
				break;
			case TouchPhase.Moved:
				DragObject (deltaPosition);
				transform.Rotate (0f, 0f, rotationSpeed * dir * Time.deltaTime);
				break;
			case TouchPhase.Ended:	
				break;
			}
		} else if (Input.touchCount == 0) {
			if (unbalanced) {
				if (transform.eulerAngles.z > 180f) { 
					transform.Rotate (0f, 0f, 200f * Time.deltaTime);
				} else {
					transform.Rotate (0f, 0f, -200f * Time.deltaTime);
				}
			}
		}
		
		if (Input.touchCount > 1) {
			if (Input.GetTouch (1).phase == TouchPhase.Began) {
				if (lightspeed == false) {
					if (sprayBulletPerk) {
						Instantiate (Resources.Load ("Spray_Bullet"), new Vector3 (transform.position.x, transform.position.y, transform.position.z + .5f), transform.rotation);
					} else if (dualBulletPerk) {
						Instantiate (Resources.Load ("Dual_Bullet"), new Vector3 (transform.position.x, transform.position.y, transform.position.z + .5f), transform.rotation);
					} else {
						Instantiate (Resources.Load ("Bullet"), new Vector3 (transform.position.x, transform.position.y, transform.position.z + .5f), new Quaternion (0.0f, 90.0f, 90.0f, 0.0f)); 
					}
				}
			}
			
		}
		
		Touch theTouch = Input.GetTouch (1);
		Ray ray = Camera.main.ScreenPointToRay (theTouch.position);
		
		if (Physics.Raycast (ray, out hit, 50.0f)) {
			if (Input.touchCount > 1 && Input.GetTouch (1).phase == TouchPhase.Began) {
				if (hit.collider.name == "Shockwave Button")
					Instantiate (Resources.Load ("Shockwave"), transform.position, Quaternion.identity);	
			}
			
		}
		
	}

	void DragObject (Vector2 deltaPosition)
	{
		cachedTransform.position = new Vector3 (Mathf.Clamp ((deltaPosition.x * dragSpeed) + cachedTransform.position.x,
			startingPos.x - _horizontalLimit, startingPos.x + _horizontalLimit), 

		Mathf.Clamp ((deltaPosition.y * dragSpeed) + cachedTransform.position.y, startingPos.y - _verticalLimit, startingPos.y + _verticalLimit),
			cachedTransform.position.z);	
	}
	
	IEnumerator RandomRotChange (float coolDown)
	{
		if (dir == 1)
			dir = -1;
		else
			dir = 1;
		//Debug.Log("Changed the direction");
		yield return new WaitForSeconds(coolDown);
		isChanged = false;
		
	}
	
	void OnGUI ()
	{
		if (GUI.Button (new Rect (Screen.width * 0.8f, Screen.height * 0.3f, Screen.width * 0.1f, Screen.height * 0.05f), "Shockwave")) {
			Instantiate (Resources.Load ("Shockwave"), transform.position, Quaternion.identity);
		}
	}
}
