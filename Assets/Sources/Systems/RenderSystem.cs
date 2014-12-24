using Entitas;
using UnityEngine;

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
			Orientation orientation = item.Get<Orientation>(CId.Orientation);
			Vector3 rotation = new Vector3(0, 0, orientation.current);
			IItemView itemView = item.Get<View>(CId.View).itemView;
			itemView.rotation = Quaternion.Euler(rotation);

			item.Get<View>(CId.View).itemView.position = item.Get<Position>(CId.Position).position;
		}
	}
}
