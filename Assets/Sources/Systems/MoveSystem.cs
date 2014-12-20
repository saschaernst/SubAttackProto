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
			var speed = UpdateSpeed(item);

			if (speed != 0)
			{
				float direction = UpdateDirection(item);
				UpdatePosition(item, speed, direction);
			}
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

		float UpdateDirection(Entity item)
		{
			Direction direction = item.Get<Direction>(CId.Direction);
			float target = direction.target;
			float current = direction.current;
			float step = direction.rotationSpeed * Time.deltaTime;

			Debug.Log(target - current);

			if (target > current + step)
			{
				direction.current += step;
			}
			else if (target < current - step)
			{
				step = -step;
				direction.current += step;
			}
			else
			{
				step = target - direction.current;
				direction.current = target;
			}

			direction.step = step;

			return direction.current;
		}

		void UpdatePosition(Entity item, float speed, float direction)
		{
			Vector3 velocity = new Vector3(0, speed * Time.deltaTime, 0);
			Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, direction));
			Position position = item.Update<Position>(CId.Position);
			position.position = position.position + rotation * velocity;
		}
	}
}
