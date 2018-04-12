using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mole : MonoBehaviour {
	// Moles are avocados the player can hit
	public float visibleHeight = 0.2f;
	public float hiddenHeight = -0.3f;

	private Vector3 targetPosition;
	public float speed = 4f;

	[SerializeField]
	public float disappearDuration = 1.25f;
	private float disappearTimer = 0f;

	// Use this for initialization
	void Awake () {
		targetPosition = new Vector3 (transform.localPosition.x, hiddenHeight, transform.localPosition.z);
		transform.localPosition = targetPosition;
	}
	
	// Update is called once per frame
	void Update () {
		disappearTimer -= Time.deltaTime;

		if (disappearTimer <= 0f) {
			Hide ();
		}

		// "Time.deltaTime * speed" is how fast the avocados move up and down
		transform.localPosition = Vector3.Lerp (transform.localPosition, targetPosition, Time.deltaTime * speed);
	}

	// Make the avocados rise
	public void Rise () {
		targetPosition = new Vector3 (transform.localPosition.x, visibleHeight, transform.localPosition.z);
		disappearTimer = disappearDuration;
	}

	public void Hide () {
		targetPosition = new Vector3 (transform.localPosition.x, hiddenHeight, transform.localPosition.z);
	}

	public void OnHit () {
		Hide ();
	}
		
}