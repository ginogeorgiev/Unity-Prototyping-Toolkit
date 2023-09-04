using UnityEngine;

namespace PrototypingToolkit.Core
{
	public abstract class FactoryData<T> : ScriptableObject, IFactory<T>
	{
		public abstract T Create();
	}
}
