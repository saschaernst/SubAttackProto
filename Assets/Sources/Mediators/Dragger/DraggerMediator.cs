using MinMVC;

namespace SubAttack
{
	public class DraggerMediator : Mediator<IDraggerView>
	{
		[Inject]
		public INavigation navigation;

		[Inject]
		public GameDispatcher dispatcher;

		protected override void OnRegister()
		{
			view.onDrag += OnDrag;
		}

		protected override void OnRemove()
		{
			view.onDrag -= OnDrag;
		}

		void OnDrag(float x, float y)
		{
			navigation.targetX = x;
			navigation.targetY = y;

			dispatcher.onDragUpdate();
		}
	}
}
