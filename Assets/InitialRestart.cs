using UnityEngine;
using System.Collections;

public class InitialRestart : MonoBehaviour {

    public static bool done = false;

	// Use this for initialization
	void Start () {
	
	  if (InitialRestart.done == false) {
	    InitialRestart.done = true;
	    Application.LoadLevel (0);
	  }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
