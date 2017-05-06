using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Rigidbody2D rb2d;
	private Collider2D floorCollider;
	public float speed;
	public float jumpForce;
	private bool canJump;
	public GameObject floor;

	void Start()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		floorCollider = floor.GetComponent<BoxCollider2D> ();
	}

	void FixedUpdate()
	{
		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//Vector2 movement = new Vector2 (moveHorizontal, 0f);
		//rb2d.AddForce (movement * speed);

		if (Input.GetKey ("d"))
		{
			rb2d.velocity = new Vector2 (speed, rb2d.velocity.y);
		} 
		else if (Input.GetKey ("a")) 
		{
			rb2d.velocity = new Vector2 (-speed, rb2d.velocity.y);
		} 
		else 
		{
			rb2d.velocity = new Vector2 (0f, rb2d.velocity.y);
		}



	}

	void LateUpdate()
	{
		if (Physics2D.IsTouching(GetComponent<CapsuleCollider2D> (), floorCollider)) 
		{
			canJump = true;
		} 
		else 
		{
			canJump = false;
		}

		//Vector2 jumping = new Vector2 (0f, jumpForce);

		if (Input.GetButtonDown("Jump") && canJump)
		{
			rb2d.velocity = new Vector2 (rb2d.velocity.x, jumpForce);
		}
	}
}
