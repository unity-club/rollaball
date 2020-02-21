using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
	// Remember: public variables are visible in the inspector
	// so we can edit them from outside of this script itself
	public float speed;

	// A reference to the Rigidbody component. Components are attached
	// to GameObjects and can do various things. This script, PlayerController,
	// is a component too!
	private Rigidbody rb;

	private void Start()
	{
		// Here we get a reference to the Rigidbody component
		// of the player object
		rb = GetComponent<Rigidbody>();
	}

	private void FixedUpdate()
	{
		// We do input calculations here because FixedUpdate() runs before
		// any physics calculations. That way the proper physics forces will run
		// at the correct time once we try to move the player.
		float moveHorizontal = Input.GetAxis("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");

		Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

		rb.AddForce(movement * speed);
	}
}
