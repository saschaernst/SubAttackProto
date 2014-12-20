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

			var targetSpeed = navigation.direction.magnitude;

			if (targetSpeed != 0)
			{
				item.Ensure<Speed>(CId.Speed).amount = targetSpeed;
			}
			else
			{
				item.Prevent(CId.Speed);
			}

			dispatcher.onNavigationUpdate();
		}
	}
}
