using Entitas;
using UnityEngine;
using MinMVC;

namespace SubAttack
{
	public class MoveSystem : EntitySystem
	{
		public MoveSystem()
		{
			_typeIds = new []{ CId.Position, CId.Speed };
		}

		protected override void Process(Entity item)
		{
			Speed speed = item.Get<Speed>(CId.Speed);
			Vector3 velocity = new Vector3(0, speed.amount, 0);
			Position position = item.Update<Position>(CId.Position);

			position.position += velocity * Time.deltaTime;
		}
	}
}
