using MinMVC;
using System;

namespace SubAttack
{
	public interface IGameView : IMediatedView
	{
		event Action onUpdate;

		IItemView CreateView(string prefabId);
	}
}
