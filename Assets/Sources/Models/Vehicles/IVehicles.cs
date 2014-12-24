using Entitas;

namespace SubAttack
{
	public interface IVehicles
	{
		void Add(string id, Entity vehicle);

		Entity Get(string id);

		Entity Remove(string id);
	}
}
