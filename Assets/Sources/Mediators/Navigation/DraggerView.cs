using UnityEngine;
using System;

namespace SubAttack
{
	public class DraggerView : MonoBehaviour
	{
		public Camera submarineCamera;

		public event Action<Vector3> onDrag;

		void OnDrag(DragGesture gesture)
		{
			float camSize = submarineCamera.orthographicSize * 2;
			float scale = camSize / Screen.height;

			Vector2 inputPosition = gesture.Position;
			inputPosition.x -= Screen.width / 2;
			inputPosition.y -= Screen.height / 2;
			inputPosition *= scale;
			transform.localPosition = inputPosition;

			onDrag(inputPosition);
		}
	}
}
