using UnityEngine;
using System.Collections;

public class FloatScript : MonoBehaviour {


	float leftBound = -25;
	float rightBound = 50;

	public float driftSpeed = 10;

	// Update is called once per frame
	void Update () {
		transform.position = new Vector3 (transform.position.x + driftSpeed * Time.deltaTime, transform.position.y, transform.position.z);
		if (transform.position.x > rightBound) {
			transform.position = new Vector3(leftBound, transform.position.y, transform.position.z);
		}
	}
}
