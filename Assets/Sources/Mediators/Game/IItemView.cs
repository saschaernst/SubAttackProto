using UnityEngine;

namespace SubAttack
{
	public interface IItemView
	{
		Vector3 position { get; set; }

		void Rotate(Vector3 rotation);
	}
}
