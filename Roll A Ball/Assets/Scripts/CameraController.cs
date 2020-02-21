using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;

	private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
		// Here we get the constant offset between the camera and the player.
		// Transform is a reference to the transform component on the player that
		// stores information about the player's position, rotation, etc...
		offset = transform.position - player.transform.position;
    }

	private void LateUpdate()
	{
		// We place the camera movement code in LateUpdate() because by the time that
		// LateUpdate() runs, all movement calculations for this GameObject will have finished
		transform.position = player.transform.position + offset;
	}
}
