using MinMVC;
using UnityEngine;
using System;

namespace SubAttack
{
	public class GameView : MediatedView, IGameView
	{
		public event Action onUpdate;

		IInjector injector = new Injector();

		protected override void Awake()
		{
			RegisterModels();
			MapMediators();
			AddSystems();
			AddCommands();
		}

		void RegisterModels()
		{
			injector.Register<GameDispatcher>();
			injector.Register<ICommands, Commands>();
			injector.Register<IMediators, Mediators>();
			injector.Register<INavigation, Navigation>();
			injector.Register<IEntityCache, EntityCache>();
			injector.Register<ISystems, Systems>();
		}

		void MapMediators()
		{
			var mediators = injector.Get<IMediators>();
			mediators.Map<IGameView, GameMediator>();
			mediators.Map<IDraggerView, DraggerMediator>();
			mediators.Map<IDirectionBarView, DirectionBarMediator>();

			mediators.Mediate(this);
		}

		void AddSystems()
		{
			var systems = injector.Get<ISystems>();
			systems.Add<MoveSystem>();
		}

		void AddCommands()
		{
			var commands = injector.Get<ICommands>();
			var dispatcher = injector.Get<GameDispatcher>();

			dispatcher.initSubmarine += commands.Get<InitSubmarine>().Execute;

			dispatcher.initSubmarine("Submarine");
		}

		public IItemView CreateView(string prefabId)
		{
			GameObject gameObj = CreateFromResources<GameObject>(prefabId);
			gameObj.transform.parent = transform;
			gameObj.transform.localPosition = Vector3.zero;
			gameObj.transform.localScale = Vector3.one;
		
			return gameObj.AddComponent<ItemView>();
		}

		T CreateFromResources<T>(string resource) where T: UnityEngine.Object
		{
			T prefab = Resources.Load<T>(resource);
			Debug.Log(resource);
			T instance = Instantiate(prefab) as T;
		
			return instance;
		}

		void Update()
		{
			onUpdate();
		}
	}
}
