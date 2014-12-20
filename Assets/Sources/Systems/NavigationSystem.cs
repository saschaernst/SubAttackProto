using Entitas;
using MinMVC;

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
			dispatcher.onNavigationUpdate();
		}
	}
}
