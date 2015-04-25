using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	void OnTriggerEnter2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.GetComponent<Mouse> ().canClimb = true;
		}
	}
	void OnTriggerExit2D (Collider2D collider) {
		if (collider.gameObject.tag == "Player") {
			collider.GetComponent<Mouse> ().canClimb = false;
		}
	}
}
