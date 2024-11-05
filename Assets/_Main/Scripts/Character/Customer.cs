namespace CHARACTER
{
    public abstract class Customer : Character
    {

        public Order Order;

        public Customer(string name) : base(name)
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