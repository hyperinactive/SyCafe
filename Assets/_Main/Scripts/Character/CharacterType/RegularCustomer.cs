using CHARACTERS;
using System;
using UnityEngine;

namespace CHARACTER
{
    class RegularCustomer : Customer
    {
        public RegularCustomer(string name, CharacterConfigData config, GameObject prefab) : base(name, config, prefab)
        {
            Debug.Log($"Spawned RegularCustomer: [{name}]");
            this.Order = GenerateOrder();
            Debug.Log($"Generated Order: [{this.Order}]");
        }

        private Order GenerateOrder()
        {
            Array orders = Enum.GetValues(typeof(Order));
            Order randomOrder = (Order)orders.GetValue(UnityEngine.Random.Range(0, orders.Length));
            return randomOrder;
        }
    }
}
