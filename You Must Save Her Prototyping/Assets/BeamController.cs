using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamController : MonoBehaviour {

	public SpriteRenderer lightBeam; 
	public BoxCollider2D beamCol;
	public bool takeDamage;

	void Start () {
		lightBeam = GetComponent<SpriteRenderer> ();
		beamCol = GetComponent<BoxCollider2D> ();
		beamCol.enabled = false;
		lightBeam.enabled = false;
		takeDamage = false;
	}


	void LateUpdate () {

		//Light Aura
		if (GameObject.Find ("Aura").GetComponent<AuraShowHide> ().lightAura.enabled == false) {
			if (Input.GetKey (KeyCode.Mouse0)) {
				lightBeam.enabled = true;
				beamCol.enabled = true;
			} else if (Input.GetKeyUp (KeyCode.Mouse0)) {
				lightBeam.enabled = false;	
				beamCol.enabled = false;
			}
		}
	}
		
	void OnTriggerStay2D(Collider2D other) 
	{
		if (other.gameObject.CompareTag ("Enemy")) {
			takeDamage = true;
		} else
			takeDamage = false;
	}

	void Update () {
		if (takeDamage == true)
		GameObject.Find ("myEnemy").GetComponent<EnemyHealth> ().health -= Time.deltaTime * 1; 
	}
		
}
