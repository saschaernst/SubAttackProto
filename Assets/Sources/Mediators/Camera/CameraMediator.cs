using MinMVC;

namespace SubAttack
{
	public class CameraMediator : Mediator<ICameraView>
	{
		[Inject]
		public GameDispatcher dispatcher;

		[Inject]
		public INavigation navigation;

		protected override void OnRegister()
		{
			dispatcher.onNavigationUpdate += OnNavigationUpdate;
		}

		protected override void OnRemove()
		{
			dispatcher.onNavigationUpdate -= OnNavigationUpdate;
		}

		void OnNavigationUpdate()
		{
			view.position = navigation.position;
		}
	}
}
