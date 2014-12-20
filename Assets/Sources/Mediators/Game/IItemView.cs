using UnityEngine;

namespace SubAttack
{
	public interface IItemView
	{
		Vector3 position { get; set; }

		Quaternion rotation { get; set; }
	}
}
