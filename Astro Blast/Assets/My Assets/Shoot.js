#pragma strict

//the bullet we are shooting must have a rigidbody
var Bullet : Transform;
//the speed the bullet is shot at
var Speed = 16000;
//where the bullet spawns (most likely the tip of the gun)
var spawnPoint : Transform;
//if we shoot like a machinegun or not
var RapidFire = false;
//if we shoot every click or not
var SingleFire = true;
//this is only used if rapid fire is set to true
private var shooting = false;
//RateOfFire private
var Counter = Time.deltaTime;
var RateOfFire = 0.250000;

function FixedUpdate ()
{
//if single fire is set to true
if(SingleFire==true){
//we are using the left mouse button to shoot
if(Input.GetButtonUp("Fire1")){
//we create the bullet
var shot =Instantiate(Bullet, spawnPoint.transform.position, Quaternion.identity);
//we add the speed
shot.rigidbody.AddForce(transform.forward * Speed); } }

if(RapidFire ==true){
if(Input.GetButtonDown("Fire1")){
shooting=true;
}

if(shooting==true){ 
Counter += Time.deltaTime;

if(RateOfFire < Counter){

var shotRapid =Instantiate(Bullet, spawnPoint.transform.position,Quaternion.identity);
//we add the speed
shotRapid.rigidbody.AddForce(transform.forward * Speed);
Counter=0; 
		} 
} 
} 
} 