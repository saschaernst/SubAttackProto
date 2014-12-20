using Entitas;
using UnityEngine;

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
			var currentSpeed = UpdateSpeed(item);
			UpdadatePosition(item, currentSpeed);
		}

		float UpdateSpeed(Entity item)
		{
			Speed speed = item.Get<Speed>(CId.Speed);
			float target = speed.target;
			float current = speed.current;
			float acceleration = speed.acceleration * Time.deltaTime;

			if (target > current + acceleration)
			{
				speed.current += acceleration;
			}
			else if (target < current - acceleration)
			{
				speed.current -= acceleration;
			}
			else
			{
				speed.current = target;
			}

			return speed.current;
		}

		void UpdadatePosition(Entity item, float current)
		{
			Vector3 velocity = new Vector3(0, current, 0);
			Position position = item.Update<Position>(CId.Position);
			position.position += velocity * Time.deltaTime;
		}
	}
}
