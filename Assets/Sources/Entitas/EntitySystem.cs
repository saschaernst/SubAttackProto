using Entitas;
using MinMVC;

namespace SubAttack
{
	public abstract class EntitySystem : IEntitySystem
	{
		[Inject]
		public IEntityCache repo { get; set; }

		EntityCollection _items;

		[PostInjection]
		public void Init()
		{
			int[] typeIds = GetTypeIds();
			_items = repo.GetCollection(typeIds);
		}

		public void Execute()
		{
			Entity[] entities = _items.GetEntities();

			for (int i = 0; i < entities.Length; i++)
			{
				Process(entities[i]);
			}
		}

		protected abstract int[] GetTypeIds();

		protected abstract void Process(Entity item);
	}
}
