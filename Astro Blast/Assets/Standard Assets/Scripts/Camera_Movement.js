#pragma strict
var target : Transform;
private var thisPosition: Transform; 
var height = 5;
var distance = -10;


function Start () {
thisPosition = transform; 
}

function Update () {

thisPosition.position = new Vector3(target.position.x, height, distance);
}