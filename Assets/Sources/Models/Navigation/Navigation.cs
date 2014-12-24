using UnityEngine;

namespace SubAttack
{
	public class Navigation : INavigation
	{
		Vector3 _orientation;
		float _minSpeed = 0.5f;

		public Vector3 orientation {
			get {
				return isMoving ? _orientation : Vector3.zero;
			}
			set {
				_orientation = value;
			}
		}

		public bool isMoving {
			get {
				return _orientation.magnitude < _minSpeed;
			}
		}

		public void UpdateDirection(Vector3 delta)
		{
			_orientation += delta;
		}

		public Vector3 position { get; set; }

		public float speed { get { return orientation.magnitude * direction; } }

		public int direction { get; set; }
	}
}
