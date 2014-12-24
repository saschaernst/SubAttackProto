using MinMVC;
using UnityEngine;

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
			view.onTap += OnTap;
			dispatcher.onNavigationUpdate += OnNavigationUpdate;
		}

		protected override void OnRemove()
		{
			view.onTap -= OnTap;
			dispatcher.onNavigationUpdate -= OnNavigationUpdate;
		}

		void OnNavigationUpdate()
		{
			view.position = navigation.position;
		}

		void OnTap(Vector2 target)
		{
			dispatcher.fireTorpedo("sub", target);
		}
	}
}
