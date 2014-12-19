using MinMVC;

namespace SubAttack
{
	public class GameView : MediatedView, IGameView
	{
		IInjector injector = new Injector();

		protected override void Awake()
		{
			RegisterModels();
			MapMediators();

		}

		void RegisterModels()
		{
			injector.Register<GameDispatcher>();
			injector.Register<ICommands, Commands>();
			injector.Register<IMediators, Mediators>();
			injector.Register<INavigation, Navigation>();
		}

		void MapMediators()
		{
			var mediators = injector.Get<IMediators>();
			mediators.Map<IGameView, GameMediator>();
			mediators.Map<IDraggerView, DraggerMediator>();
			mediators.Map<IDirectionBarView, DirectionBarMediator>();

			mediators.Mediate(this);
		}
	}
}
