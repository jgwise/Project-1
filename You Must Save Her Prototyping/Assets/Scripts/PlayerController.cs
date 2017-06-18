using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Animator playerAnim;
	public float speed;
	public float jumpForce;
	bool facingRight = true;
	bool grounded = false;
	public Transform groundCheck;
	float groundRadius = 0.2f;
	public LayerMask whatIsGround;
	private Animation lightAura;
	public Transform playerTransform;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		playerAnim = GetComponent<Animator> ();
		playerTransform = GetComponent<Transform> ();
	}

	void FixedUpdate()
	{
		//Ground check
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundRadius, whatIsGround);
		playerAnim.SetBool ("Ground", grounded);

		playerAnim.SetFloat ("vSpeed", rb2d.velocity.y);

		//Movement
		float move = Input.GetAxis ("Horizontal");
		rb2d.velocity = new Vector2 (move * speed, rb2d.velocity.y);
		playerAnim.SetFloat ("Speed", Mathf.Abs (move));

		//Direction check
		if (move > 0 && !facingRight) 
			Flip ();	
		else if (move < 0 && facingRight)
			Flip ();
	}

	//Flip direction function
	void Flip ()
	{
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
	}


	void Update()
	{
		//Jump Code
		if (grounded && Input.GetButtonDown ("Jump")) 
		{
			playerAnim.SetBool ("Ground", false);
			rb2d.AddForce(new Vector2 (0, jumpForce));
		} 
	}
}
