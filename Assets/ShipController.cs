using UnityEngine;
using System;

public class ShipController : MonoBehaviour
{
	public float speed;
	public float acceleration;

	float _targetSpeed = 0f;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			UpdateSpeed (1);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			UpdateSpeed (-1);
		}
	}

	void UpdateSpeed (int dir)
	{
		var nextSpeed = _targetSpeed + speed * dir;

		if (nextSpeed < -2) {
			_targetSpeed = -2;
		} else if (nextSpeed > 4) {
			_targetSpeed = 4;
		} else {
			_targetSpeed = nextSpeed;
		}
	}

	void FixedUpdate ()
	{
		var delta = _targetSpeed - rigidbody2D.velocity.y;

		if (delta != 0) {
			var vec = new Vector2 ();

			if (delta > 0) {
				vec.y = Math.Min (acceleration, delta);
			} else if (delta < 0) {
				vec.y = Math.Max (-acceleration, delta);
			}

			rigidbody2D.AddForce (vec);
		}

		Debug.Log (rigidbody2D.velocity + " " + delta);
	}
}
