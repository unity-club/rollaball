using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotator : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
		// We use transform.Rotate(Vector3 eulerAngles) to rotate this GameObject's transform
		// eulerAngles.x degrees around the x-axis, eulerAngles.y degrees around the y-axis, and
		// eulerAngles.z degrees around the z-axis. However, to make this movement framerate
		// independent, we multiply this Vector3 by Time.deltaTime, which is the change in time
		// between the current and last frame. That way, if we are running on a very fast computer
		// with a framerate of 400 FPS, or a slow computer with a framerate of 100 FPS, the cube will be
		// rotated by the same number of degrees per second.
		//
		// Feel free to learn more about this here:
		// https://learn.unity.com/tutorial/delta-time#5c8a677eedbc2a001f47d749
		transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
