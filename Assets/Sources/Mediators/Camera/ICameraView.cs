using MinMVC;
using UnityEngine;
using System;

namespace SubAttack
{
	public interface ICameraView : IMediatedView
	{
		event Action<Vector2> onTap;

		Vector3 position { set; }
	}
}
