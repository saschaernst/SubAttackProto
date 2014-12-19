using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public class DirectionBarView : MediatedView, IDirectionBarView
	{
		public void SetAngle(float x, float y)
		{
			var angle = Mathf.Atan2(y, x) * Mathf.Rad2Deg - 90;
			transform.localEulerAngles = new Vector3(0, 0, angle);
		}

		public void SetScale(float x, float y)
		{
			var scale = transform.localScale;
			scale.y = Mathf.Sqrt(x * x + y * y);
			transform.localScale = scale;
		}
	}
}
