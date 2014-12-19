using Entitas;

namespace SubAttack
{
	public abstract class EntitySubsystem : IReactiveSubEntitySystem
	{
		protected int[] _typeIds;
		protected EntityCollectionEventType _eventType = EntityCollectionEventType.OnEntityAdded;

		public IEntityMatcher GetTriggeringMatcher()
		{
			return Matcher.AllOf(_typeIds);
		}

		public EntityCollectionEventType GetEventType()
		{
			return _eventType;
		}

		public void Execute(Entity[] entities)
		{
			for (int i = 0, length = entities.Length; i < length; i++)
			{
				Process(entities[i]);
			}
		}

		protected abstract void Process(Entity item);
	}
}
