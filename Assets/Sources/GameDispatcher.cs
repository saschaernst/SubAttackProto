using System;

namespace SubAttack
{
	public class GameDispatcher
	{
		public Action<View> addView;

		public Action<string> initSubmarine;

		public Action onNavigationUpdate;
	}
}
