using Entitas;

namespace SubAttack
{
	public interface IEntityCache
	{
		Entity CreateEntity();

		void DestroyEntity(Entity item);

		EntityCollection GetCollection(int[] typeIds);

		EntityRepository repo { get; }
	}
}
