using UnityEngine;
using System.Collections;

/* This script is the gaze system that allows the user to
 * interact with objects simply by looking around.
 * To use, make sure that the interactable object has
 * a script tag called "InteractEye" on it, unless
 * otherwise specified
 */
public class GazeSystem : MonoBehaviour {

  public GameObject gazeCursor;
  public static GameObject cursor; //the gaze cursor
  
  public string interactTag = "Interactable";
  public string activateMethod = "Activate";

  private Ray gazeRay; //this will be the ray used for raycasting
  RaycastHit interactableObject; //interactable object that the user is looking at
  private Animator cursorAnimator; //cursor animation
  
  private bool looking = false; //checks if the user is looking at a button
  private bool alreadyActivated = false; //checks if animation was activated 
  
  private string animBool = "activateCursor"; //boolean tag on the animator

  // Use this for initialization
  void Start () {
  
    cursor = this.gameObject; //makes this object accessible from all other scripts
    cursorAnimator = gazeCursor.GetComponent<Animator>(); //sets the animator
    placeOnCamera();
	
  }
	
  // Update is called once per frame
	void Update () {
	
	    RaycastHit hitObject;
		
		//creates new ray for raycast
		gazeRay = new Ray (this.transform.position, this.transform.forward);
		
		//performs Raycast infinitely forward, stores hit objects into targetedEye
		if (Physics.Raycast(gazeRay, out hitObject, Mathf.Infinity)) {
		
		    GameObject hit = hitObject.collider.gameObject;
			
			//checks the tag of the hit object - should be InteractEye
			if ((hit.GetComponent<PaperLook>() &&
			    !hit.GetComponent<PaperLook>().moving &&
			    !hit.GetComponent<PaperLook>().moved &&
			    !PaperLook.activePaper) ||
			    
			    (hit.GetComponent<MovePaperBack>() &&
				!hit.GetComponent<MovePaperBack>().paperScript.moving &&
			     hit.GetComponent<MovePaperBack>().paperScript.moved) ||
			    
			    (hit.GetComponent<FinalChoice>() &&
			     hit.GetComponent<FinalChoice>().doctorNotes.finishedOnce &&
			     hit.GetComponent<FinalChoice>().patientInfo.finishedOnce &&
			     !hit.GetComponent<FinalChoice>().alreadyActivated) ||
			     
			     hit.GetComponent<FinalChoiceOption>() &&
			     FinalChoiceOption.readyForChoice)
			    
			{
				
				//if the animation hasn't already been activated
				if (alreadyActivated == false) {
					looking = true; //user is looking
					cursorAnimator.SetBool (animBool, true); //start animation
				}
			}
			
			//deactivate the cursor animation if the user looks at something else
			else {
				
				DeactivateCursor();
				
			}
		}
		
		//deactivate the cursor animation if the user looks at nothing
		else {
			
			DeactivateCursor();
			
		}
		
		//If the user looked at the object for the full cursor animation (95% of it, at least)
		if (looking == true && cursorAnimator.GetCurrentAnimatorStateInfo(0).normalizedTime > 0.95) {
			
			//Checks if the object has the script we want
			if (hitObject.collider.gameObject.GetComponent<PaperLook>()) {
				
				//Calls the Activate() method on the script
				hitObject.collider.gameObject.GetComponent<PaperLook>().paperLook();	    
			}
			
			else if (hitObject.collider.gameObject.GetComponent<MovePaperBack>()) {
				
				hitObject.collider.gameObject.GetComponent<MovePaperBack>().movePaper();
				
			}
			
			else if (hitObject.collider.gameObject.GetComponent<FinalChoice>()) {
			
			  hitObject.collider.gameObject.GetComponent<FinalChoice>().startFinalChoice();
			
			}
			
			else if (hitObject.collider.GetComponent<FinalChoiceOption>()) {
			  
			  hitObject.collider.GetComponent<FinalChoiceOption>().Activate();
			
			}
			
			DeactivateCursor(); //deactivate the cursor
			
			alreadyActivated = true; //cursor has been activated- animation wont auto run again
			cursorAnimator.speed = 0; //stop the cursor animation
			
		}
  }
  
  /* Deactivates the cursor by setting it back toward the beginning */
  void DeactivateCursor() {
 
    looking = false; //user not looking
    if (cursorAnimator) {
      cursorAnimator.Play (0); //start over
      cursorAnimator.SetBool (animBool, false); //set bool flag to false
	  alreadyActivated = false; //cursor is not activated
	  cursorAnimator.speed = 1; //set speed back to normal
    }

  }
  
  void placeOnCamera() {
  
    this.transform.parent = Camera.main.transform;
    this.transform.localPosition = new Vector3(0,0,0);
    
  
  }
}
