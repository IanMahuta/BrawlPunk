using UnityEngine;
using System.Collections;

public class FadeScript : MonoBehaviour {

	SpriteRenderer r;

	void Start() {
		r = GetComponent<SpriteRenderer> ();

	}

	void OnTriggerEnter2D(Collider2D other) {
		if (other.CompareTag ("Player"))
			r.enabled = false;
	}

	void OnTriggerExit2D(Collider2D other) {
		if (other.CompareTag ("Player"))
			r.enabled = true;
	}
}
