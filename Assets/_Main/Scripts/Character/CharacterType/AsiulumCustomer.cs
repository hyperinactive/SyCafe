using CHARACTERS;
using UnityEngine;

namespace CHARACTER
{
    class AsilumCustomer : Customer
    {
        // TODO: adding it manually for now
        public AsilumCustomer(string name, CharacterConfigData config, GameObject prefab) : base(name, config, prefab)
        {
            Debug.Log($"Spawned AsiulumCustomer: [{name}]");
        }
    }
}
