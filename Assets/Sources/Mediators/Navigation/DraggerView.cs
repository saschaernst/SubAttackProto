using UnityEngine;
using System;

namespace SubAttack
{
	public class DraggerView : MonoBehaviour
	{
		public Camera submarineCamera;
		public DragRecognizer dragger;

		public event Action<Vector3> onDrag;

		void Start()
		{
			dragger.OnGesture += OnDrag;
		}

		void OnDrag(DragGesture gesture)
		{
			Debug.Log(">>>> drag " + gesture.DeltaMove);
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
