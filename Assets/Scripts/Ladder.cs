using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.GetComponent<MouseMove> ().canClimb = true;
		}
	}
	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.GetComponent<MouseMove> ().canClimb = false;
		}
	}
}
