using MinMVC;
using System;
using UnityEngine;

namespace SubAttack
{
	public interface IDraggerView : IMediatedView
	{
		event Action<Vector3> onDrag;
	}
}
