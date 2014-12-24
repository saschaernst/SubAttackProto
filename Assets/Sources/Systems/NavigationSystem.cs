using Entitas;
using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public class NavigationSystem : EntitySubsystem
	{
		[Inject]
		public INavigation navigation;

		[Inject]
		public GameDispatcher dispatcher;

		public NavigationSystem()
		{
			_typeIds = new [] { CId.Navigation, CId.Position };
		}

		protected override void Process(Entity item)
		{
			Position position = item.Update<Position>(CId.Position);
			navigation.position = position.position;

			item.Get<Speed>(CId.Speed).target = navigation.speed;

			if (navigation.speed != 0)
			{
				Vector2 orientation = navigation.orientation;
				float target = Mathf.Atan2(orientation.y, orientation.x) * Mathf.Rad2Deg - 90;

				if (target < -180f)
				{
					target += 360;
				}

				item.Get<Orientation>(CId.Orientation).target = target;
			}
			
			dispatcher.onNavigationUpdate();
		}
	}
}
