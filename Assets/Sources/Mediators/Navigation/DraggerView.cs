using UnityEngine;
using System;

namespace SubAttack
{
	public class DraggerView : MonoBehaviour
	{
		public Camera submarineCamera;

		public event Action<Vector3> onDrag;
		//
		//		public Vector3 position {
		//			set {
		//				transform.position = value;
		//			}
		//		}

		void OnDrag(DragGesture gesture)
		{
			float camSize = submarineCamera.orthographicSize * 2;
			float scale = camSize / Screen.height;
			Vector2 delta = gesture.DeltaMove;
			Vector3 position = transform.position;
			position.x += delta.x * scale;
			position.y += delta.y * scale;
			transform.position = position;

			onDrag(position);
		}
	}
}
