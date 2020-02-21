using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This line gives us access to Unity's UI classes, which we will need to update the counter at the top-left of the screen.
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
	// Remember: public variables are visible in the inspector
	// so we can edit them from outside of this script itself
	public float speed;

	// A reference to the Text component in the top left of the screen
	public Text countText;
	public Text winText;

	// A reference to the Rigidbody component. Components are attached
	// to GameObjects and can do various things. This script, PlayerController,
	// is a component too!
	private Rigidbody rb;

	private int count;

	private void Start()
	{
		// Here we get a reference to the Rigidbody component
		// of the player object
		rb = GetComponent<Rigidbody>();

		count = 0;
		SetCountText();
		winText.text = string.Empty; // an empty string, equivalent to "" but more readable
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

	private void OnTriggerEnter(Collider other)
	{
		// First, we will check that the GameObject of the collider
		// we are colliding with has the tag "Pick Up". If it does,
		// we will deactivate the pick up.
		if (other.gameObject.CompareTag("Pick Up"))
		{
			// Now, we set the GameObject we are colliding with to be inactive.
			other.gameObject.SetActive(false);

			// Increment our count by one because we have just collected a Pick Up
			count = count + 1;
			SetCountText();
		}
	}

	// Here is an example of the principle of abstraction. We are avoiding having
	// duplicate code in our script by externalizing it into a separate function, SetCountText()
	//
	// See: https://en.wikipedia.org/wiki/Abstraction_(computer_science)
	private void SetCountText ()
	{
		countText.text = "Count: " + count.ToString();
		if (count >= 12)
		{
			winText.text = "You Win!";
		}
	} 
}
