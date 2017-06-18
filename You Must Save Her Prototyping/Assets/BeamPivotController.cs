using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamPivotController : MonoBehaviour {

	private Vector3 mousep;
	public Transform beamPivot; //Assign to the object you want to rotate
	private Vector3 objectpos;
	private float angle;

	// Use this for initialization
	void Start () {
		beamPivot = GetComponent<Transform> ();
	}

	void fixedUpdate () {


	}

	void LateUpdate () {

		mousep = Input.mousePosition;
		mousep.z = 5.23f; //The distance between the camera and objects
		objectpos = Camera.main.WorldToScreenPoint(beamPivot.position);
		mousep.x = mousep.x - objectpos.x;
		mousep.y = mousep.y - objectpos.y;
		angle = Mathf.Atan2(mousep.y, mousep.x) * Mathf.Rad2Deg;
		beamPivot.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

		beamPivot.position = GameObject.Find ("Player").GetComponent<PlayerController> ().playerTransform.position;



	}
}
