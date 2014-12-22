using MinMVC;
using UnityEngine;
using System;

namespace SubAttack
{
	public class CameraView : MediatedView, ICameraView
	{
		public PinchRecognizer pincher;

		public Vector3 offset;
		public float minSize = 3f;
		public float maxSize = 50f;
		public float zoom = 10f;

		protected override void Start()
		{
			base.Start();

			pincher.OnGesture += OnPinch;
		}

		public Vector3 position {
			set {
				Vector3 position = transform.localPosition;
				position.x = value.x;
				position.y = value.y;
				transform.localPosition = position + offset;
			}
		}

		public void OnPinch(PinchGesture gesture)
		{
			var cam = Camera.main;
			var size = cam.orthographicSize - gesture.Delta / zoom;
			size = Math.Max(minSize, size);
			size = Math.Min(maxSize, size);
			cam.orthographicSize = size;
		}
	}
}
