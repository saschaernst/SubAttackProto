using MinMVC;

namespace SubAttack
{
	public interface IDirectionBarView : IMediatedView
	{
		void SetAngle(float targetX, float targetY);

		void SetScale(float targetX, float targetY);
	}
}
