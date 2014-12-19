using Entitas;

namespace SubAttack
{
	public class DefaultComponent : IComponent
	{
		static readonly IComponent _instance = new DefaultComponent();

		public static IComponent instance { get { return _instance; } }

		DefaultComponent()
		{
		}
	}
}
