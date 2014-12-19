using System;

namespace SubAttack
{
	public class GameDispatcher
	{
		public Action onDragUpdate;

		public Action<View> addView;

		public Action<string> initSubmarine;
	}
}
