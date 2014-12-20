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

		public Vector3 direction {
			set {
				directionBar.SetAngle(value);
				directionBar.SetScale(value);
			}
		}

		public override void OnMediate()
		{
			dragger.onDrag += onDrag;
		}
	}
}
