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
			Orientation direction = item.Get<Orientation>(CId.Orientation);
			float rotationSpeed = direction.rotationSpeed * Time.deltaTime;
			float target = direction.target;
			float current = CalcCurrent(direction.current, target);

			if (target > current + rotationSpeed)
			{
				direction.current += rotationSpeed;
			}
			else if (target < current - rotationSpeed)
			{
				direction.current -= rotationSpeed;
			}
			else
			{
				direction.current = target;
			}

			return direction.current;
		}

		float CalcCurrent(float current, float target)
		{
			float delta = target - current;
			float dir = delta > 0 ? 1 : -1;

			if (delta * dir > 180 && current * dir < 0)
			{
				current += 360 * dir;
			}

			return current;
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
