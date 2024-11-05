using UnityEngine;

namespace CHARACTER
{
    class AsilumCustomer : Customer
    {
        // TODO: adding it manually for now
        public AsilumCustomer(string name, Order order) : base(name)
        {
            Debug.Log($"Spawned AsiulumCustomer: [{name}]");
            Order = order;
        }
    }
}
