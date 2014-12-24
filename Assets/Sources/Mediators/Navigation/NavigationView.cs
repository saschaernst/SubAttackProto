using MinMVC;
using UnityEngine;
using System;

namespace SubAttack
{
	public class NavigationView : MediatedView, INavigationView
	{
		public DirectionBarView directionBar;
		public DraggerView dragger;

		public event Action<Vector3> onDrag;

		public Vector3 position {
			set {
				transform.localPosition = value;
			}
		}

		public void UpdateDirection(Vector3 position, Vector3 direction)
		{
			directionBar.SetAngle(direction);
			directionBar.SetScale(direction);
			dragger.SetPosition(position + direction);
		}

		public override void OnMediate()
		{
			dragger.onDrag += onDrag;
		}
	}
}
