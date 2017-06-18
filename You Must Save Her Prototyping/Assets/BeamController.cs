using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour {

	public SpriteRenderer lightBeam; 

	void Start () {
		lightBeam = GetComponent<SpriteRenderer> ();
		lightBeam.enabled = false;
	}


	void LateUpdate () {

		//Light Aura
		if (GameObject.Find ("Aura").GetComponent<AuraShowHide> ().lightAura.enabled == false) {
			if (Input.GetKey (KeyCode.Mouse0))
				lightBeam.enabled = true;
			else if (Input.GetKeyUp (KeyCode.Mouse0))
				lightBeam.enabled = false;	
		}
	}
}
