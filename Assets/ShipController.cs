using UnityEngine;

public class ShipController : MonoBehaviour
{
	public float speed;

	float _targetSpeed = 0f;
	float _currentSpeed = 0f;
	float _deltaSpeed = 0f;

	Vector2 _force = new Vector2 ();

	void Start ()
	{
		rigidbody2D.inertia = 10f;
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.UpArrow)) {
			_targetSpeed += speed;
			rigidbody2D.AddForce (new Vector2 (0, speed), ForceMode2D.Impulse);
		} else if (Input.GetKeyDown (KeyCode.DownArrow)) {
			_targetSpeed = 0;
		}
//
//		if (_currentSpeed < _targetSpeed) {
//			_deltaSpeed = speed;
//		} else if (_currentSpeed > _targetSpeed) {
//			_deltaSpeed = -speed;
//		} else {
//			_deltaSpeed = 0;
//		}
	}

	void FixedUpdate ()
	{
		//		_currentSpeed += _deltaSpeed;
		//		var force = new Vector2 (0, _deltaSpeed / 10);
		//		rigidbody2D.AddForce (force);
		//
		Debug.Log (rigidbody2D.velocity + " " + rigidbody2D.inertia);
	}
}
