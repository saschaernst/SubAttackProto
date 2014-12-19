using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public interface IDirectionBarView : IMediatedView
	{
		void SetPosition(Vector3 position);

		void SetAngle(Vector3 direction);

		void SetScale(Vector3 direction);
	}
}
