using System;
using UnityEngine;

namespace CHARACTER
{
    class RegularCustomer : Customer
    {
        public RegularCustomer(string name) : base(name)
        {
            Debug.Log($"Spawned RegularCustomer: [{name}]");
            Order = GenerateOrder();
        }

        private Order GenerateOrder()
        {
            Array orders = Enum.GetValues(typeof(Order));
            Order randomOrder = (Order)orders.GetValue(UnityEngine.Random.Range(0, orders.Length));
            return randomOrder;
        }
    }
}
