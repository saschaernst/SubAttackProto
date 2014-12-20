using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public interface ICameraView : IMediatedView
	{
		Vector3 position { set; }
	}
}
