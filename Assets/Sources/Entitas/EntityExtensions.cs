using Entitas;

namespace SubAttack
{
	public static class EntityExtensions
	{
		public static T AddComponent<T>(this Entity entity, int index) where T: IComponent, new()
		{
			T component = new T();
			entity.AddComponent(index, component);

			return component;
		}

		public static void AddComponent(this Entity entity, int index)
		{
			entity.AddComponent(index, DefaultComponent.instance);
		}

		public static IComponent EnsureComponent(this Entity entity, int index)
		{
			if (!entity.HasComponent(index))
			{
				entity.AddComponent(index, DefaultComponent.instance);
			}

			return entity.GetComponent(index);
		}

		public static T EnsureComponent<T>(this Entity entity, int index) where T: IComponent, new()
		{
			if (!entity.HasComponent(index))
			{
				entity.AddComponent<T>(index);
			}

			return entity.GetComponent<T>(index);
		}

		public static T GetComponent<T>(this Entity entity, int index) where T: IComponent
		{
			return (T)entity.GetComponent(index);
		}

		public static void UpdateComponent(this Entity entity, int index)
		{
			if (entity.HasComponent(index))
			{
				var comp = entity.GetComponent(index);
				entity.ReplaceComponent(index, comp);
			}
		}

		public static void PreventComponent(this Entity entity, int index)
		{
			if (entity.HasComponent(index))
			{
				entity.RemoveComponent(index);
			}
		}

		public static T RemoveComponent<T>(this Entity entity, int index) where T: IComponent
		{
			T comp = entity.GetComponent<T>(index);
			entity.RemoveComponent(index);

			return comp;
		}
	}
}
