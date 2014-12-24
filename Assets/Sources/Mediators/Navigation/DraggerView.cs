using UnityEngine;
using System;

namespace SubAttack
{
	public class DraggerView : MonoBehaviour
	{
		public Camera submarineCamera;
		public DragRecognizer dragger;

		public event Action<Vector3> onDrag;

		public void SetPosition(Vector3 position)
		{
			transform.position = position;
		}

		void Start()
		{
			dragger.OnGesture += OnDrag;
		}

		void OnDrag(DragGesture gesture)
		{
			float camSize = submarineCamera.orthographicSize * 2;
			float scale = camSize / Screen.height;
			Vector2 delta = gesture.DeltaMove * scale;
//			Vector3 position = new Vector3();
//			position.x += delta.x * scale;
//			position.y += delta.y * scale;
			//transform.position = position;

			onDrag(delta);
		}
	}
}
