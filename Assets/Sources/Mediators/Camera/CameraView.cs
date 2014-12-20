using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public class CameraView : MediatedView, ICameraView
	{
		public Vector3 offset;

		public Vector3 position {
			set {
				Vector3 position = transform.localPosition;
				position.x = value.x;
				position.y = value.y;
				transform.localPosition = position + offset;
			}
		}
	}
}
