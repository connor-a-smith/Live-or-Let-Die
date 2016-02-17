using UnityEngine;
using System.Collections;

public class FadeOut : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	  StartCoroutine(fadeOut());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	IEnumerator fadeOut() {
	
	  while (this.GetComponent<MeshRenderer>().material.color.a > 0) {
			
		Color tempColor = this.GetComponent<MeshRenderer>().material.color;
		tempColor.a-=0.01f;
			
		this.GetComponent<MeshRenderer>().material.SetColor("_Color", tempColor);
		
		yield return null;
			
	}
	
	gameObject.SetActive(false);
  }
}
