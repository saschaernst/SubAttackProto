using MinMVC;
using System;

namespace SubAttack
{
	public interface IDraggerView : IMediatedView
	{
		event Action<float, float> onDrag;
	}
}
