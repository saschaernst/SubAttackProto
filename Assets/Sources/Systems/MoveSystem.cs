using Entitas;
using UnityEngine;

namespace SubAttack
{
	public class MoveSystem : EntitySystem
	{
		protected override int[] GetTypeIds()
		{
			return new [] { CId.Position };
		}

		protected override void Process(Entity item)
		{
			Debug.Log(item);
		}
	}
}
