using System.Collections.Generic;
using Entitas;
using MinMVC;

namespace SubAttack
{
	public class Systems : ISystems
	{
		[Inject]
		public IInjector injector;

		readonly IList<IEntitySystem> _systems = new List<IEntitySystem>();

		public void Add<T>() where T: IEntitySystem, new()
		{
			T system = new T();
			injector.Inject(system);
			_systems.Add(system);
		}

		public void Execute()
		{
			for (int i = 0; i < _systems.Count; i++)
			{
				IEntitySystem system = _systems[i];
				system.Execute();
			}
		}
	}
}
