
var ball : Transform; //I am dragging ball to this in the inspector
var height : float; //height of my camera
var behind : float; //the constant distance the camera is behind the ball 

function Update ()
{	
	height = 4;
	behind = 10;
	//camera position the same as ball, plus height and distance behind it
	transform.position = ball.transform.position + Vector3(behind, height, 0);
}