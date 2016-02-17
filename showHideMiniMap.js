#pragma strict

    var show : boolean = true;
    var target : GameObject;
    function Update ()
    {
    if(Input.GetKeyDown(KeyCode.I))
	    {
	    	if( show == false )
		    {
			    guiTexture.enabled = true;
			    show = true;
		    }
     	
	    }
	    
	    if(Input.GetKeyUp(KeyCode.I))
		   {
			  	guiTexture.enabled = false;
			    show = false;
		   }
    }