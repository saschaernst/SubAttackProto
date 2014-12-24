using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public class NavigationMediator : Mediator<INavigationView>
	{
		[Inject]
		public INavigation navigation;

		[Inject]
		public GameDispatcher dispatcher;

		protected override void OnRegister()
		{
			view.onDrag += OnDrag;

			dispatcher.onNavigationUpdate += OnNavigationUpdate;

			UpdateDirection();
		}

		protected override void OnRemove()
		{
			view.onDrag -= OnDrag;

			dispatcher.onNavigationUpdate -= OnNavigationUpdate;
		}

		void OnDrag(Vector3 delta)
		{
			bool isMoving = navigation.isMoving;
			navigation.UpdateDirection(delta);

			//navigation.direction = target - navigation.position;
			UpdateDirection();
		}

		void UpdateDirection()
		{
			view.UpdateDirection(navigation.position, navigation.orientation);
		}

		void OnNavigationUpdate()
		{
			view.position = navigation.position;
		}
	}
}
