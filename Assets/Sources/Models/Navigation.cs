using UnityEngine;

namespace SubAttack
{
	public class Navigation : INavigation
	{
		public Vector3 target { get; set; }

		public Vector3 position { get; set; }

		public Vector3 direction {
			get {
				return target - position;
			}
		}
	}
}
