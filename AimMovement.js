
static var speed : int = 5;

var upDir : float = 1.0f;
var downDir : float  = -1.0f;
var leftDir : float  = -1.0f;
var rightDir : float  = 1.0f;

function Start()
{
	
}
function Update () {
			//if the up Arrow is pressed increase the y position of the "Aim" object.
				if(Input.GetKey(KeyCode.UpArrow))
				{
					transform.Translate (Vector3(0,upDir,0) * Time.deltaTime*speed);				
				}					
			
				//if the Down Arrow is pressed decrease the y position of the "Aim" object.
				if (Input.GetKey (KeyCode.DownArrow)) 
				{
					transform.Translate (Vector3(0,downDir,0) * Time.deltaTime*speed);
					
				}
				
				//if the Left Arrow is pressed decrease the z position of the "Aim" object.
				if (Input.GetKey (KeyCode.LeftArrow)) 
				{
					transform.Translate (Vector3(0,0,leftDir) * Time.deltaTime*speed);
				}
				
				//if the Right Arrow is pressed increase the z position of the "Aim" object.
					if (Input.GetKey (KeyCode.RightArrow)) 
				{
						transform.Translate (Vector3(0,0,rightDir) * Time.deltaTime*speed);
				}
				
				
			
		}
		


