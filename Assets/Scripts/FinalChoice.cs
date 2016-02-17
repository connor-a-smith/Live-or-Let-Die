using UnityEngine;
using System.Collections;

public class FinalChoice : MonoBehaviour {

    public LerpScale finalpaper;
    
    public PaperLook patientInfo;
    public PaperLook doctorNotes;
    
    public bool alreadyActivated = false;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void startFinalChoice() {
	
	  alreadyActivated = true;
	  finalpaper.startGrowing();
	  finalpaper.GetComponent<PaperLook>().paperLook();
	
	}
}
