using MinMVC;
using UnityEngine;

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

		void OnDrag(Vector3 target)
		{
			navigation.target = target;

			dispatcher.onDragUpdate();
		}
	}
}
