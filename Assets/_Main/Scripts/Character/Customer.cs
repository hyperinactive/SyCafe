using CHARACTERS;
using UnityEngine;

namespace CHARACTER
{
    public abstract class Customer : Character
    {

        public Order Order;

        public Customer(string name, CharacterConfigData config, GameObject prefab) : base(name, config, prefab)
        {
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

    //nova chocolate
    //snow chocolate
    //suz x aka jiji is vanilla
    //me biscuit
    //hyper carrot
    //bobby sponge
    //Karma lemon pie
    //Syrex apple pie
}