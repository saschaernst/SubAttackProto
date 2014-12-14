using UnityEngine;
using System;

public class ShipController : MonoBehaviour
{
	public float speed;
	public float acceleration;
	public float drag;
	public float rotSpeed;

	int _targetSpeed = 0;
	float _currentSpeed = 0f;

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			UpdateTargetSpeed (1);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			UpdateTargetSpeed (-1);
		}

		UpdateSpeed ();
		UpdateRotation ();
		UpdatePosition ();
	}

	void UpdateTargetSpeed (int dir)
	{
		var nextSpeed = _targetSpeed + dir;

		if (nextSpeed < -2) {
			_targetSpeed = -2;
		} else if (nextSpeed > 4) {
			_targetSpeed = 4;
		} else {
			_targetSpeed = nextSpeed;
		}
	}

	void UpdateSpeed ()
	{
		float thrust = Time.deltaTime * acceleration * _targetSpeed;

		if (_targetSpeed == 0) {
			if (_currentSpeed < -drag) {
				_currentSpeed += drag;
			} else if (_currentSpeed > drag) {
				_currentSpeed -= drag;
			} else {
				_currentSpeed = 0;
			}
		} else if (_targetSpeed > 0) {
			if (_currentSpeed < _targetSpeed - thrust) {
				_currentSpeed += thrust;
			} else if (_currentSpeed > _targetSpeed + drag) {
				_currentSpeed -= drag;
			} else {
				_currentSpeed = _targetSpeed;
			}
		} else if (_targetSpeed < 0) {
			if (_currentSpeed + thrust > _targetSpeed) {
				_currentSpeed += thrust;
			} else if (_currentSpeed + drag < _targetSpeed) {
				_currentSpeed += drag;
			} else {
				_currentSpeed = _targetSpeed;
			}
		}
	}

	void UpdateRotation ()
	{
		if (_currentSpeed != 0) {
			var dir = _currentSpeed / Math.Abs (_currentSpeed);
			var deltaR = Input.GetAxis ("Horizontal") * rotSpeed * dir * Time.deltaTime;
			transform.Rotate (new Vector3 (0, 0, -deltaR));
		}
	}

	void UpdatePosition ()
	{
		Vector3 velocity = new Vector3 (0, _currentSpeed * speed, 0);
		Vector3 pos = transform.position;
		pos += transform.rotation * velocity;
		transform.position = pos;
	}
}
