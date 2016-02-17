using UnityEngine;
using System.Collections;

public class SimpleRaycast : MonoBehaviour {

	// We don't use start in our script
	void Start () { }
	
	// Update is called once per frame
	void Update () {
	
	  //creates a new ray to Raycast
	  Ray myRay = new Ray(Camera.main.transform.position, 
	                      Camera.main.transform.forward);
	                      
	  Debug.DrawRay(Camera.main.transform.position, Camera.main.transform.forward);
	                      
	  RaycastHit hitObject; //stores RayCast result
	  
	  //Performs the actual Raycast
	  if (Physics.Raycast(myRay, out hitObject, Mathf.Infinity)) {
	  
	    //Checks if the object has the script we want
	    if (hitObject.collider.gameObject.GetComponent<PaperLook>()) {
	    
	      //Calls the Activate() method on the script
	      hitObject.collider.gameObject.GetComponent<PaperLook>().paperLook();	    
	    }
	    
	    else if (hitObject.collider.gameObject.GetComponent<MovePaperBack>()) {
	    
	    
	      hitObject.collider.gameObject.GetComponent<MovePaperBack>().movePaper();
	    
	    }
	  }
	}
}
