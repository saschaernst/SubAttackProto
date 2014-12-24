using MinMVC;
using UnityEngine;

namespace SubAttack
{
	public class FireTorpedo : Command<string, Vector2>
	{
		public override void Execute(string id, Vector2 target)
		{
			Debug.Log(">>> fire torpedo from " + id + " at " + target);
		}
	}
}
