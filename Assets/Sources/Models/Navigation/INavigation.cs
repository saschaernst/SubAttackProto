using UnityEngine;

namespace SubAttack
{
	public interface INavigation
	{
		Vector3 position { get; set; }

		Vector3 direction { get; set; }
	}
}
