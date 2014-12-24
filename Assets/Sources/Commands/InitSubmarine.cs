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

		[Inject]
		public IVehicles vehicles;

		public override void Execute(string prefabId)
		{
			var submarine = entities.CreateEntity();
			vehicles.Add("sub", submarine);

			submarine.Add<Position>(CId.Position);
			submarine.Add(CId.Navigation);
			submarine.Add<Speed>(CId.Speed).acceleration = 1f;
			submarine.Add<Orientation>(CId.Orientation).rotationSpeed = 10f;

			var view = submarine.Add<View>(CId.View);
			view.prefabId = prefabId;

			dispatcher.addView(view);
		}
	}
}
