using CHARACTERS;
using UnityEngine;

namespace CHARACTER
{
    public abstract class Customer : Character
    {

        public Order Order;

        public Customer(string name, CharacterConfigData config, GameObject prefab) : base(name, config, prefab)
        {
            this.Order = config.Order;
        }
    }

    public enum CustomerType
    {
        Regular,
        Asilum
    }

    public enum Order
    {
        Bagel,
        Cupcake,
        Tea,
        Donut,
        Sandwich,
        Muffin
    }
}