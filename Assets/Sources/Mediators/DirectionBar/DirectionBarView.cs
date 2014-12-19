using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public class DirectionBarView : MediatedView, IDirectionBarView
	{
		public void SetPosition(Vector3 position)
		{
			transform.localPosition = position;
		}

		public void SetAngle(Vector3 direction)
		{
			var angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
			transform.localEulerAngles = new Vector3(0, 0, angle);
		}

		public void SetScale(Vector3 direction)
		{
			var scale = transform.localScale;
			scale.y = Mathf.Sqrt(direction.x * direction.x + direction.y * direction.y);
			transform.localScale = scale;
		}
	}
}
