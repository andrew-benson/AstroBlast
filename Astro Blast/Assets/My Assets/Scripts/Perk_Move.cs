using UnityEngine;
using System.Collections;

public class Perk_Move: MonoBehaviour {

	// Use this for initialization
	public float velocity;
	float zstart;
	float zpos,xpos,ypos;
	float minSpeed = -4.5f, 
	maxSpeed = -5.5f, 
	minX=-0.31f, 
	maxX=0.31f, 
	minY=-0.5f, 
	maxY=0.5f;
	float rotSpeed,xrot,yrot,zrot;
	public float minRotSpeed = 15f, maxRotSpeed = 25f;
	void Start () {
		
		//assign position and velocity for each instantiation
		
		//maxSpeed = -3.0f;
		
		rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);
		velocity = Random.Range(minSpeed, maxSpeed);
		
		zpos = Random.Range(10f, 15f);
		xpos = Random.Range(minX, maxX);
		ypos = Random.Range(minY, maxY);
	}
	
	void Update () {		
		zpos += velocity * Time.deltaTime;
		
		xrot += rotSpeed * Time.deltaTime;
		yrot += rotSpeed * Time.deltaTime;
		zrot += rotSpeed * Time.deltaTime;
		
		transform.position = new Vector3(xpos, ypos, zpos);			
		transform.eulerAngles = new Vector3 (xrot, yrot, zrot);

		if(transform.position.z < -3.5f) Destroy(gameObject);
		
	}
}
