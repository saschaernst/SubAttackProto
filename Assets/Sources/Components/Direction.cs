using Entitas;

namespace SubAttack
{
	public class Direction : IComponent
	{
		public float current;
		public float target;
		public float rotationSpeed;
		public float step;
	}
}
