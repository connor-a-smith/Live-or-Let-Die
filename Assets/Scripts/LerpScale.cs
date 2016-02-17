using UnityEngine;
using System.Collections;

public class LerpScale : MonoBehaviour {

    private Vector3 endScale;

	// Use this for initialization
	void Start () {
	
	  endScale = this.transform.localScale;
	  this.transform.localScale = new Vector3(0,0,0);
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void startGrowing() {
	
		StartCoroutine(grow ());
	}
	
	
	IEnumerator grow() {
	
	  Vector3 startScale = this.transform.localScale;
	  
	  float speed = this.GetComponent<PaperLook>().paperMoveDuration;
	  
	  for (float i = 0; i < speed; i+=Time.deltaTime) {
	  
	    this.transform.localScale = Vector3.Lerp(startScale, endScale, i/speed);
	    yield return null;
	  
	  }
	}
}
