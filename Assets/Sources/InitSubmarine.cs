using MinMVC;
using Entitas;

namespace SubAttack
{
	public class InitSubmarine : Command<string>
	{
		[Inject]
		public IEntityCache entities;

		[Inject]
		public GameDispatcher dispatcher;

		public override void Execute(string prefabId)
		{
			var submarine = entities.CreateEntity();

			submarine.Add<Position>(CId.Position);

			submarine.Add(CId.Navigation);

			var speed = submarine.Add<Speed>(CId.Speed);
			speed.acceleration = 1f;

			var direction = submarine.Add<Direction>(CId.Direction);
			direction.rotationSpeed = 20f;

			var view = submarine.Add<View>(CId.View);
			view.prefabId = prefabId;

			dispatcher.addView(view);
		}
	}
}
