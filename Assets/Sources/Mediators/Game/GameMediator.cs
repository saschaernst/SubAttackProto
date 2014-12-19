using MinMVC;

namespace SubAttack
{
	public class GameMediator : Mediator<IGameView>
	{
		[Inject]
		public GameDispatcher dispatcher;

		[Inject]
		public ISystems systems;

		protected override void OnRegister()
		{
			dispatcher.addView += AddView;

			view.onUpdate += OnUpdate;
		}

		protected override void OnRemove()
		{
			dispatcher.addView -= AddView;

			view.onUpdate -= OnUpdate;
		}

		void AddView(View v)
		{
			v.itemView = view.CreateView(v.prefabId);
		}

		void OnUpdate()
		{
			systems.Execute();
		}
	}
}
