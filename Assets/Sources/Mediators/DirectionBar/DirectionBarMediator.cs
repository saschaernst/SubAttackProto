using MinMVC;

namespace SubAttack
{
	public class DirectionBarMediator : Mediator<IDirectionBarView>
	{
		[Inject]
		public INavigation navigation;

		[Inject]
		public GameDispatcher dispatcher;

		protected override void OnRegister()
		{
			dispatcher.onDragUpdate += OnDragUpdate;
		}

		protected override void OnRemove()
		{
			dispatcher.onDragUpdate -= OnDragUpdate;
		}

		void OnDragUpdate()
		{
			view.SetAngle(navigation.targetX, navigation.targetY);
			view.SetScale(navigation.targetX, navigation.targetY);
		}
	}
}
