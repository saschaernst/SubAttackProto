using Entitas;

namespace SubAttack
{
	public interface ISystems
	{
		void Add<T>() where T: IEntitySystem, new();

		void AddReactive<T>() where T: IReactiveSubEntitySystem, new();

		void Execute();
	}
}
