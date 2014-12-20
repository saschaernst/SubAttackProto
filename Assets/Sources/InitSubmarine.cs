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

			var view = submarine.Add<View>(CId.View);
			view.prefabId = prefabId;

			dispatcher.addView(view);
		}
	}
}
