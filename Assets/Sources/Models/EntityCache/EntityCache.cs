using Entitas;
using MinMVC;

namespace SubAttack
{
	public class EntityCache : IEntityCache
	{
		public EntityRepository repo { get; private set; }

		[PostInjection]
		public void Init()
		{
			repo = new EntityRepository(1000);
		}

		public Entity CreateEntity()
		{
			return repo.CreateEntity();
		}

		public void DestroyEntity(Entity item)
		{
			repo.DestroyEntity(item);
		}

		public EntityCollection GetCollection(int[] typeIds)
		{
			var matcher = new AllOfEntityMatcher(typeIds);

			return repo.GetCollection(matcher);
		}
	}
}
