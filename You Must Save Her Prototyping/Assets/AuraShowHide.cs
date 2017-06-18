using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AuraShowHide : MonoBehaviour {

	public SpriteRenderer lightAura; 

	void Start () {
		lightAura = GetComponent<SpriteRenderer> ();
		lightAura.enabled = false;
	}


	void LateUpdate () {

		//Light Aura
		if (GameObject.Find ("Light Beam Sprite").GetComponent<BeamController> ().lightBeam.enabled == false) {
			if (Input.GetKey (KeyCode.Mouse1))
				lightAura.enabled = true;
			else if (Input.GetKeyUp (KeyCode.Mouse1))
				lightAura.enabled = false;
		}
	}
}