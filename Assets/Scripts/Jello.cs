using UnityEngine;
using System.Collections;

public class Jello : MonoBehaviour {
	public float wobbleAmpl = 0.25f;
	public float wobbleSpeed = 10.0f;
	public float dampingFactor = 2.0f;
	float time = 0;

	public void Wobble () {
		time += Time.deltaTime;
		float Y = wobbleAmpl * Mathf.Pow (2, -time*2) * Mathf.Sin (time * wobbleSpeed);
		transform.localScale = new Vector3 (1,1 + Y,1);
		if (time > 2.0f) {
			time = 0;
			transform.localScale = new Vector3 (1, 1, 1);
			CancelInvoke ("Wobble");
		}
	}

	void OnCollisionEnter2D (Collision2D collision) {
		if (collision.gameObject.tag == "Player") {
			CancelInvoke ("Wobble");
			InvokeRepeating ("Wobble", 0, 0.01f);
		}
	}
}
