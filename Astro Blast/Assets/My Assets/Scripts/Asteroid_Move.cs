using UnityEngine;
using System.Collections;

public class Asteroid_Move: MonoBehaviour {
	public bool linearMove = false;
	public static float shipVelocity = 20f;
	float xRange = 1.6f, yRange = 0.8f;
	private float velocityZ, velocityX, velocityY;
	public static int motor = 1;
	private float zpos,xpos,ypos;
	private float xrot, yrot, zrot, rotSpeed;
	//-2 and -3 by default
	//change to public for altered speeds
	public float minVelocity = -2.0f, maxVelocity = -3f, minRotSpeed = 15f, maxRotSpeed = 25f;
	

	public void Reset(){

		velocityZ = Random.Range(minVelocity, maxVelocity);
		velocityX = Random.Range(-0.3f, 0.3f);
		velocityY = Random.Range(-0.1f, 0.1f);

		zpos = Random.Range(31f, 35f);
		xpos = Random.Range(-xRange, xRange);
		ypos = Random.Range(-yRange, yRange);
		
		gameObject.transform.rotation = new Quaternion(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f),0f);
		/*
		zrot = Random.Range(1f, 3f);
		xrot = Random.Range(1f, 3f);
		yrot = Random.Range(1f, 3f);
		*/
	}

	void Start () {
		
		
		//Random.seed = 2;
		velocityZ = Random.Range(minVelocity, maxVelocity);
		velocityX = Random.Range(-0.4f, 0.4f);
		velocityY = Random.Range(-0.2f, 0.2f);
		zpos = Random.Range(31f, 35f);
		xpos = Random.Range(-xRange, xRange);
		ypos = Random.Range(-yRange, yRange);
		
		
		rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
		zrot = Random.Range(-7f, 7f);
		xrot = Random.Range(-7f, 7f);
		yrot = Random.Range(-4f, 4f);
		
	}
	
	
	void Update () {		
		
		zpos += velocityZ * shipVelocity * Time.deltaTime * motor;

		if(!linearMove){
			ypos += velocityY * Time.deltaTime * motor;
			xpos += velocityX * Time.deltaTime * motor;
		}

		xrot += rotSpeed * Time.deltaTime * motor;
		yrot += rotSpeed * Time.deltaTime * motor;
		zrot += rotSpeed * Time.deltaTime * motor;
		
		transform.position = new Vector3(xpos, ypos, zpos);	
		transform.eulerAngles = new Vector3 (xrot, yrot, zrot);
		
				
		if(transform.position.z < 0.5f) 
			Reset();
	}
}
