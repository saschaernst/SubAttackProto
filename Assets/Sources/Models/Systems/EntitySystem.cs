using Entitas;
using MinMVC;

namespace SubAttack
{
	public abstract class EntitySystem : IEntitySystem
	{
		[Inject]
		public IEntityCache entitites { get; set; }

		protected int[] _typeIds;
		EntityCollection _items;

		[PostInjection]
		public void Init()
		{
			_items = entitites.GetCollection(_typeIds);
		}

		public void Execute()
		{
			Entity[] entities = _items.GetEntities();

			for (int i = 0, length = entities.Length; i < length; i++)
			{
				Process(entities[i]);
			}
		}

		protected abstract void Process(Entity item);
	}
}
