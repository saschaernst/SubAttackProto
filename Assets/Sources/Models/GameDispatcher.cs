using System;
using UnityEngine;

namespace SubAttack
{
	public class GameDispatcher
	{
		public Action<View> addView;

		public Action<string> initSubmarine;

		public Action onNavigationUpdate;

		public Action<string, Vector2> fireTorpedo;
	}
}
