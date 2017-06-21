using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour {
	 
	public double health;
	public SpriteRenderer enemy;

	// Use this for initialization
	void Start () {
		enemy = GetComponent<SpriteRenderer> ();
		health = 1.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (health < 0.001f) {
			this.gameObject.SetActive (false);
		}
		Debug.Log (health);
	}
}
 