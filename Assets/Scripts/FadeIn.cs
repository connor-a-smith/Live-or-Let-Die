using UnityEngine;
using System.Collections;

public class FadeIn : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	  StartCoroutine(fadeIn());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator fadeIn() {
	
	  while (this.GetComponent<MeshRenderer>().material.color.a < 1) {
			
		Color tempColor = this.GetComponent<MeshRenderer>().material.color;
		tempColor.a+=0.01f;
			
		this.GetComponent<MeshRenderer>().material.SetColor("_Color", tempColor);
		
		yield return null;
			
	}
  }
}
