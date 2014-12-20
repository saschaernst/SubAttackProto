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
			Direction direction = item.Get<Direction>(CId.Direction);
			Vector3 rotation = new Vector3(0, 0, direction.current);
			IItemView itemView = item.Get<View>(CId.View).itemView;
			itemView.rotation = Quaternion.Euler(rotation);

			item.Get<View>(CId.View).itemView.position = item.Get<Position>(CId.Position).position;
		}
	}
}
