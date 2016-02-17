var amplitude: float = 5; // platform excursion (+/- 5 units, in this case)
var speed: float = 0.2; // movements per second
var direction: Vector3 = Vector3.forward; // direction relative to the platform
private var place: Vector3;

function Start()
	{
		place = transform.position;
		while (true)
		{
			// convert direction to local space
			var dir = transform.TransformDirection(direction);
			// set platform position:
			transform.position = place+amplitude*dir*Mathf.Sin(8*speed*Time.time);
			yield; //using yield here to delay until the next frame
		}
}