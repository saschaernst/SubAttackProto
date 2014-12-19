using System.Collections.Generic;
using Entitas;
using MinMVC;

namespace SubAttack
{
	public class Systems : ISystems
	{
		[Inject]
		public IInjector injector;

		[Inject]
		public IEntityCache entities { get; set; }

		readonly IList<IEntitySystem> _systems = new List<IEntitySystem>();

		public void Add<T>() where T: IEntitySystem, new()
		{
			T system = new T();
			injector.Inject(system);
			_systems.Add(system);
		}

		public void AddReactive<T>() where T: IReactiveSubEntitySystem, new()
		{
			T system = new T();
			injector.Inject(system);

			var reactor = new ReactiveEntitySystem(entities.repo, system);
			_systems.Add(reactor);
		}

		public void Execute()
		{
			for (int i = 0, count = _systems.Count; i < count; i++)
			{
				IEntitySystem system = _systems[i];
				system.Execute();
			}
		}
	}
}
