using MinMVC;

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
			submarine.AddComponent<Position>(CId.Position);
			var view = submarine.AddComponent<View>(CId.View);
			view.prefabId = prefabId;

			dispatcher.addView(view);
		}
	}
}
