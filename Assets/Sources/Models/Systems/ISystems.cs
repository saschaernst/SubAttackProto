using Entitas;

namespace SubAttack
{
	public interface ISystems
	{
		void Add<T>() where T: IEntitySystem, new();

		void Execute();
	}
}
