using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
	// The hammer to hit the avocados
	public int score = 0;
	public Hammer hammer;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (GvrViewer.Instance.Triggered || Input.GetKeyDown ("space")) {
			// GvrViewerMain will be replaced by GvrEditorEmulator in newest version of VR SDK
			// GvrViewer is unknown in new versions of the VR SDK
			RaycastHit hit;

			if (Physics.Raycast (transform.position, transform.forward, out hit)) {
				// print the name of the avocado we hit
				if (hit.transform.GetComponent<Mole>() != null){
					Mole mole = hit.transform.GetComponent<Mole> ();
					mole.OnHit ();
					hammer.Hit (mole.transform.position);
					score++;
				}

			}
	    }
	}
}
