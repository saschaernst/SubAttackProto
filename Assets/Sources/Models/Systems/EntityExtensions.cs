using Entitas;

namespace SubAttack
{
	public static class EntityExtensions
	{
		public static bool Has(this Entity entity, int index)
		{
			return entity.HasComponent(index);
		}

		public static T Add<T>(this Entity entity, int index) where T: IComponent, new()
		{
			T component = new T();
			entity.AddComponent(index, component);

			return component;
		}

		public static void Add(this Entity entity, int index)
		{
			entity.AddComponent(index, DefaultComponent.instance);
		}

		public static IComponent Ensure(this Entity entity, int index)
		{
			if (!entity.HasComponent(index))
			{
				entity.AddComponent(index, DefaultComponent.instance);
			}

			return entity.GetComponent(index);
		}

		public static T Ensure<T>(this Entity entity, int index) where T: IComponent, new()
		{
			if (!entity.HasComponent(index))
			{
				entity.Add<T>(index);
			}

			return entity.Get<T>(index);
		}

		public static T Get<T>(this Entity entity, int index) where T: IComponent
		{
			return (T)entity.GetComponent(index);
		}

		public static void Update(this Entity entity, int index)
		{
			if (entity.HasComponent(index))
			{
				var comp = entity.GetComponent(index);
				entity.ReplaceComponent(index, comp);
			}
		}

		public static T Update<T>(this Entity entity, int index) where T: IComponent
		{
			entity.Update(index);

			return entity.Get<T>(index);
		}

		public static void Prevent(this Entity entity, int index)
		{
			if (entity.HasComponent(index))
			{
				entity.RemoveComponent(index);
			}
		}

		public static T Remove<T>(this Entity entity, int index) where T: IComponent
		{
			T comp = entity.Get<T>(index);
			entity.RemoveComponent(index);

			return comp;
		}
	}
}
