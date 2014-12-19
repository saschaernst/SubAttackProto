using Entitas;

namespace SubAttack
{
	public class RenderSystem : EntitySubsystem
	{
		public RenderSystem()
		{
			_typeIds = new [] { CId.View, CId.Position };
		}

		protected override void Process(Entity item)
		{
			item.Get<View>(CId.View).itemView.position = item.Get<Position>(CId.Position).pos;
		}
	}
}
