using UnityEngine;
using System.Collections;

public class PCControls : MonoBehaviour {

	public bool sprayBulletPerk;
	public bool dualBulletPerk;

	public bool lightSpeed = false;
	float movSpeed = 0.6f;
	public float horizontalLimit = 1f, verticalLimit = 0.5f;
	
	
	void Awake(){
		
	}

	void OnMouseDrag(){

	}
	
	// Update is called once per frame
	void Update () {
		Vector3 mousePosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, 2f);
		Vector3 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
		transform.position = new Vector3(objPosition.x, objPosition.y,1f);
		Vector3 bulletPos = new Vector3(transform.position.x,transform.position.y, transform.position .z + 0.5f);

		//transform.Translate(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"),transform.position.z);
	/*
	   if (Input.GetKey(KeyCode.S)){
			transform.Translate(new Vector3(0.0f,-movSpeed,0f)*Time.deltaTime);
			if(transform.position.y <=  -verticalLimit) transform.position = new Vector3( transform.position.x, -verticalLimit, transform.position.z);
		}
		
		if (Input.GetKey(KeyCode.W)){transform.Translate(new Vector3(0f,movSpeed,0f)*Time.deltaTime);
			if(transform.position.y >=  verticalLimit) transform.position = new Vector3( transform.position.x, verticalLimit, transform.position.z);}

		if (Input.GetKey(KeyCode.D)){transform.Translate(new Vector3(movSpeed,0f,0f)*Time.deltaTime);
			if(transform.position.x >=  horizontalLimit) transform.position = new Vector3( horizontalLimit, transform.position.y, transform.position.z);}

		if (Input.GetKey(KeyCode.A)){transform.Translate(new Vector3(-movSpeed,0f,0f)*Time.deltaTime);
			if(transform.position.x <=  -horizontalLimit) transform.position = new Vector3( -horizontalLimit, transform.position.y, transform.position.z);}
	*/	


		if(Input.GetMouseButtonDown(0)){
			if(lightSpeed == false){
				if(sprayBulletPerk){ 
					Instantiate(Resources.Load("Spray_Bullet"), bulletPos, new Quaternion(0.0f,0.0f,90.0f,0.0f));
				}
				else if(dualBulletPerk){
					Instantiate(Resources.Load("Dual_Bullet"), bulletPos, new Quaternion(0.0f,0.0f,90.0f,0.0f));
				}
				else {
					Instantiate(Resources.Load("Bullet"), bulletPos, new Quaternion(0.0f,90.0f,90.0f,0.0f));
				}
			}
		}
		if(Input.GetKeyDown(KeyCode.P)){
			Instantiate(Resources.Load("Shockwave"), transform.position, Quaternion.identity);
		}
	}
}