using UnityEngine;
using System.Collections;

public class MovePaperBack : MonoBehaviour {

    private float paperMoveDuration;
    private Vector3 startPosition;
    private Vector3 endPosition;
    private Quaternion startRotation;
    private Quaternion endRotation;
    private GameObject paperObject;

    private bool moved = false;
    private bool moving = true;

    public PaperLook paperScript;

	// Use this for initialization
	void Start () {
	
	  paperObject = paperScript.gameObject;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void movePaper() {
	
	  if (paperScript.moved) {
	
		startPosition = paperScript.startPosition;
		endPosition = paperScript.endPosition;
		startRotation = paperScript.startRotation;
		endRotation = paperScript.endRotation;
		paperMoveDuration = paperScript.paperMoveDuration;
		
		paperScript.moved = false;
		paperScript.moving = true;
		StartCoroutine(movePaperBack ());
		
		
      }
	}
	
	IEnumerator movePaperBack() {
		
		for (float i = 0f; i < paperMoveDuration; i+=Time.deltaTime) {
			
			paperObject.transform.position = Vector3.Lerp(endPosition, startPosition, i/paperMoveDuration);
			paperObject.transform.rotation = Quaternion.Lerp (endRotation, startRotation, i/paperMoveDuration);
			
			yield return null;
			
		}
		
		paperScript.moving = false;
		paperScript.moved = false;
		paperScript.finishedOnce = true;
		PaperLook.activePaper = false;
		
	}
}
