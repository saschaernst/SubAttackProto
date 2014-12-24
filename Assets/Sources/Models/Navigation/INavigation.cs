using UnityEngine;

namespace SubAttack
{
	public interface INavigation
	{
		Vector3 position { get; set; }

		Vector3 orientation { get; set; }

		bool isMoving { get; }

		void UpdateDirection(Vector3 delta);

		float speed { get; }

		int direction { get; set; }
	}
}
