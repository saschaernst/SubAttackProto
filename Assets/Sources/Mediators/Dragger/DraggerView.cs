using UnityEngine;
using MinMVC;
using System;

namespace SubAttack
{
	public class DraggerView : MediatedView, IDraggerView
	{
		public Camera submarineCamera;

		public event Action<Vector3> onDrag;

		void OnDrag(DragGesture gesture)
		{
			float camSize = submarineCamera.orthographicSize * 2;
			float scale = camSize / Screen.height;
			Vector2 delta = gesture.DeltaMove;
			Vector3 pos = transform.position;
			pos.x += delta.x * scale;
			pos.y += delta.y * scale;
			transform.position = pos;

			onDrag(pos);
		}
	}
}
