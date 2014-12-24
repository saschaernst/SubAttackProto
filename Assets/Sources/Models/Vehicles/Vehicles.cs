using System.Collections.Generic;
using Entitas;

namespace SubAttack
{
	public class Vehicles : IVehicles
	{
		IDictionary<string, Entity> _vehicles = new Dictionary<string, Entity>();

		public void Add(string id, Entity vehicle)
		{
			_vehicles[id] = vehicle;
		}

		public Entity Get(string id)
		{
			Entity vehicle;

			_vehicles.TryGetValue(id, out vehicle);

			return vehicle;
		}

		public Entity Remove(string id)
		{
			Entity vehicle = Get(id);

			if (vehicle != null)
			{
				_vehicles.Remove(id);
			}

			return vehicle;
		}
	}
}

