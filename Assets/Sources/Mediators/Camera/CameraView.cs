using MinMVC;
using UnityEngine;
using System;

namespace SubAttack
{
	public class CameraView : MediatedView, ICameraView
	{
		[SerializeField]
		PinchRecognizer pincher;
		[SerializeField]
		TapRecognizer tapper;
		[SerializeField]
		Vector3 offset;
		[SerializeField]
		float minSize = 3f;
		[SerializeField]
		float maxSize = 50f;
		[SerializeField]
		float zoom = 10f;

		public event Action<Vector2> onTap;

		public Vector3 position {
			set {
				Vector3 position = transform.localPosition;
				position.x = value.x;
				position.y = value.y;
				transform.localPosition = position + offset;
			}
		}

		protected override void Start()
		{
			base.Start();

			pincher.OnGesture += OnPinch;
			tapper.OnGesture += OnTap;
		}

		void OnPinch(PinchGesture gesture)
		{
			var size = camSize - gesture.Delta / zoom;
			size = Math.Max(minSize, size);
			size = Math.Min(maxSize, size);
			camSize = size;
		}

		void OnTap(TapGesture gesture)
		{
			Vector2 tapPos = gesture.Position;
			tapPos.x -= Screen.width / 2;
			tapPos.y -= Screen.height / 2;

			float scale = camSize * 2 / Screen.height;
			tapPos *= scale;

			Vector3 cameraPos = transform.localPosition;
			tapPos.x += cameraPos.x;
			tapPos.y += cameraPos.y;

			onTap(tapPos);
		}

		float camSize {
			get {
				return Camera.main.orthographicSize;
			}
			set {
				Camera.main.orthographicSize = value;
			}
		}
	}
}
