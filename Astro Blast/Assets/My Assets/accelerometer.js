#pragma strict

var force : float = 1.0;
var simulateAccelerometer : boolean = false;

function Start()
{
	Screen.orientation = ScreenOrientation.Landscape ; //iphoneScreenOrientation.Landscape		
}

function Update()
{
	
	var dir : Vector3 = Vector3.zero; //dir(0,0,0)
	
	//enable simulateAccelerometer - uses keys
	if(simulateAccelerometer)
	{
		dir.x = Input.GetAxis("Horizontal"); //input from left/right key
		dir.z = Input.GetAxis("Vertical"); // input from up/down key
	}
	else
	//enable mobile input : uses accelerometer
	{
		
		dir.x = -Input.acceleration.y;
		dir.z = Input.acceleration.x;
		
		if(dir.sqrMagnitude > 1) dir.Normalize();
		//if(Input.GetKeyDown("Jump"))
		
	
	}
	 
	 
	rigidbody.AddForce(dir * force);
	

}