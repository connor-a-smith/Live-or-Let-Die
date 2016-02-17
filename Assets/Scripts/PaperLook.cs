using UnityEngine;
using System.Collections;

public class PaperLook : MonoBehaviour {

    public static bool activePaper = false;
 
    public float camDistance;
    public float paperMoveDuration;
    public Quaternion paperRotation;
 
    public bool finishedOnce = false;
    
    public Vector3 startPosition;
    public Vector3 endPosition;
    public bool moving = false;
    public bool moved = true;
    
    public Quaternion startRotation;
    public Quaternion endRotation;
    
    public bool isPill = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void paperLook() {
	
	  if (!moving && !moved) {
	    PaperLook.activePaper = true;
	    moving = true;
	    StartCoroutine(movePaper());
	  }
	
	}
	
	IEnumerator movePaper() {
	
		startPosition = this.transform.position;
		endPosition = new Vector3 (Camera.main.transform.position.x, 
		                                   Camera.main.transform.position.y, 
		                                   Camera.main.transform.position.z + camDistance);
		
		startRotation = this.transform.rotation;
		//this.transform.LookAt(lookLocation.transform.position);
		 endRotation = paperRotation;
		//this.transform.rotation = startRotation;
		
		
		for (float i = 0f; i < paperMoveDuration; i+=Time.deltaTime) {
		
		  this.transform.position = Vector3.Lerp(startPosition, endPosition, i/paperMoveDuration);
		  this.transform.rotation = Quaternion.Lerp (startRotation, endRotation, i/paperMoveDuration);
		  
		  yield return null;
	
	  }
		moving = false;
		moved = true;
	}
	
	IEnumerator movePaperBack() {
	
		for (float i = 0f; i < paperMoveDuration; i+=Time.deltaTime) {
			
			this.transform.position = Vector3.Lerp(endPosition, startPosition, i/paperMoveDuration);
			this.transform.rotation = Quaternion.Lerp (endRotation, startRotation, i/paperMoveDuration);
			
			yield return null;
			
		}
	}
}
