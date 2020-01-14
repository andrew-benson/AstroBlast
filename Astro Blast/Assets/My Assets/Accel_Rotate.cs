using UnityEngine;
using System.Collections;

public class Accel_Rotate : MonoBehaviour {
	public GameObject rotateTarget;
	// Use this for initialization
	public float accx,calibx, accy,caliby;
	
	void Start () {
		calibx = Input.acceleration.x *Time.deltaTime;//-0.015
        caliby = Input.acceleration.y *Time.deltaTime;//-0.015

	
	}
	
	// Update is called once per frame
	void Update () {
	  
		
		
		Vector3 axisX = Vector3.right;
		Vector3 axisY = Vector3.up;
		Vector3 axisZ = Vector3.forward;
		accx = Input.acceleration.x *Time.deltaTime-calibx;//should be 0
        accy = -Input.acceleration.y *Time.deltaTime-caliby;
		
		if (axisX.sqrMagnitude > 1) axisX.Normalize();
		if (axisY.sqrMagnitude > 1) axisY.Normalize();


		
		rotateTarget.transform.RotateAround(axisX,accy);
		rotateTarget.transform.RotateAround(axisY,accx);
		if(rotateTarget.transform.rotation.z > 0)
		rotateTarget.transform.RotateAround(axisZ,0);	

	}
}
