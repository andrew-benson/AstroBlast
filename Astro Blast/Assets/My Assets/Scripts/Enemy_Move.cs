using UnityEngine;
using System.Collections;

public class Enemy_Move: MonoBehaviour {
	public bool linearMove = false;
	public static float shipVelocity = 20f;
	float xRange = 1.4f, yRange = 0.7f;
	private float velocityZ, velocityX, velocityY;
	public static int motor = 1;
	private float zpos,xpos,ypos;
	private float xrot, yrot, zrot, rotSpeed;
	public float minVelocity = -2.0f, maxVelocity = -3f, minRotSpeed = 15f, maxRotSpeed = 25f;
	bool isActive = true;

	public void Reset(){

		velocityZ = Random.Range(minVelocity, maxVelocity);
		velocityX = Random.Range(-0.3f, 0.3f);
		velocityY = Random.Range(-0.1f, 0.1f);

		zpos = Random.Range(20f, 25f);
		xpos = Random.Range(-xRange, xRange);
		ypos = Random.Range(-yRange, yRange);
		
		rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);		
		isActive = true;
	}

	void Start () {
		
		
		//Random.seed = 2;
		velocityZ = Random.Range(minVelocity, maxVelocity);
		velocityX = Random.Range(-0.4f, 0.4f);
		velocityY = Random.Range(-0.2f, 0.2f);
		zpos = Random.Range(8.0f, 16f);
		xpos = Random.Range(-xRange, xRange);
		ypos = Random.Range(-yRange, yRange);
		
		
		rotSpeed = Random.Range(minRotSpeed, maxRotSpeed);		
		
	}
	
	
	void Update () {		
		
		zpos += velocityZ * shipVelocity * Time.deltaTime * motor;
		zrot += rotSpeed * Time.deltaTime;
		if(!linearMove){
			ypos += velocityY * Time.deltaTime * motor;
			xpos += velocityX * Time.deltaTime * motor;
		}
		
		transform.position = new Vector3(xpos, ypos, zpos);	
		//transform.eulerAngles = new Vector3 (xrot, yrot, zrot);
		transform.eulerAngles = new Vector3 (0, 0, zrot);

				
		if(isActive)
			if(transform.position.z < 0.5f){
				float aResetTimer = Random.Range(20f,50f);
				Invoke("Reset",aResetTimer);
				isActive = false;
		}
	}
	
	IEnumerator EnemyCoroutine(float timeTilSpawn){
		yield return new WaitForSeconds(timeTilSpawn);
		Reset();
	}
}
