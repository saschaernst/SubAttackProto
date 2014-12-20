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
		}

		protected override void OnRemove()
		{
			view.onDrag -= OnDrag;

			dispatcher.onNavigationUpdate -= OnNavigationUpdate;
		}

		void OnDrag(Vector3 target)
		{
			navigation.target = target;
		}

		void OnNavigationUpdate()
		{
			view.position = navigation.position;
		}
	}
}
