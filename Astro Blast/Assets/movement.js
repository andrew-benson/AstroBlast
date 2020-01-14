#pragma strict


var speed : float = .2;
function Start () {

}

function Update () {

		
	var i : int = 0 ;
		
		if(Input.touchCount>0){
		if (Input.GetTouch (0).phase == TouchPhase.Moved) {
		
			var ray : Ray = Camera.main.ScreenPointToRay (Input.GetTouch (i).position);
				
			if (Physics.Raycast (ray)) {
				var touchDeltaPosition : Vector2 = Input.GetTouch (i).deltaPosition;
				var touchPosition : Vector2 = Input.GetTouch (i).position;
				var xMove : float = touchDeltaPosition.x * speed * Time.deltaTime ;
				var yMove : float = touchDeltaPosition.y * speed * Time.deltaTime ;
				transform.Translate(xMove, yMove, 0);
				transform.position.x = Mathf.Clamp(transform.position.x, -1.5f, 1.5f);
				transform.position.y = Mathf.Clamp(transform.position.y, -0.5f, 0.5f);

				
				
				
			}
				
		}
				
	}
	


}