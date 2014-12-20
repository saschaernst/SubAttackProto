using System;
using UnityEngine;
using MinMVC;

namespace SubAttack
{
	public interface INavigationView : IMediatedView
	{
		event Action<Vector3> onDrag;

		Vector3 position { set; }
	}
}
