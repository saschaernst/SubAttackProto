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

			Vector2 direction = navigation.direction;
			float target = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;

			if (target < -180f)
			{
				target += 360;
			}

			item.Get<Direction>(CId.Direction).target = target;

			dispatcher.onNavigationUpdate();
		}
	}
}
