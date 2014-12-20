using UnityEngine;

namespace SubAttack
{
	public class ItemView : MonoBehaviour, IItemView
	{
		public Vector3 position {
			get {
				return transform.localPosition;
			}
			set {
				transform.localPosition = value;
			}
		}

		public Quaternion rotation {
			get {
				return transform.localRotation;
			}
			set {
				transform.localRotation = value;
			}
		}
	}
}
