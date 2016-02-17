using UnityEngine;
using System.Collections;

public class FinalChoiceOption : MonoBehaviour {

    public bool yes;
    public TextMesh titleText;
    public FinalChoiceOption otherScript;
    public GameObject endFadePlane;
    
    public float fadeSpeed;
    
	private string startText = "Approve Patient Request\nFor Life-Ending Medication?";
    private string yesText = "Are You Sure You Want To\nLet The Patient End His Life?";
    private string noText = "Are You Sure You Want To\nRefuse The Patient?";
    
    private string textToSet;
    
    public static bool readyForChoice = true;
    private Material tempMat;

	// Use this for initialization
	void Start () {
	
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void Activate() {
	
	  if (yes) {  
	    if (string.Equals(titleText.text, startText)) {
	  
	      textToSet = yesText;
		  StartCoroutine(fade());
	     
	    }
	    
	    else {
	    
	      StartCoroutine(endGame ());
	    
	    }
	  }
	  
	  else {
	  
	    if (string.Equals(titleText.text, startText)) {
	    
	      textToSet = noText;
	    
	    }
	    
	    else {
	    
	      textToSet = startText;
	    
	    }
	    
	    StartCoroutine(fade());
	  }
	}
	
	
    IEnumerator fade() {
    
	  FinalChoiceOption.readyForChoice = false;
    
      while (titleText.font.material.color.a > 0) {
      
		Color tempColor = titleText.font.material.color;
        tempColor.a-=fadeSpeed;
          
		titleText.font.material.SetColor("_Color", tempColor);
        
        yield return null;
      
      }
      
      titleText.text = textToSet;
      
      while (titleText.font.material.color.a < 1) {
        Color tempColor = titleText.font.material.color;
        tempColor.a+=fadeSpeed;
        
        titleText.font.material.SetColor("_Color", tempColor);

        
        yield return null;
      
      }
      
      FinalChoiceOption.readyForChoice = true;
    }
    
    IEnumerator endGame() {
    
      FinalChoiceOption.readyForChoice = false;
      
      endFadePlane.SetActive(true);
      
	  while (endFadePlane.GetComponent<MeshRenderer>().material.color.a < 1) {
	    Debug.Log ("RUNNING");
      
        Color tempColor = endFadePlane.GetComponent<MeshRenderer>().material.color;
        tempColor.a+=fadeSpeed;
        
		endFadePlane.GetComponent<MeshRenderer>().material.SetColor("_Color", tempColor);
        
        yield return null;
      
      }
   	
	 Application.LoadLevel(1);
	 
    }
    

    
}
