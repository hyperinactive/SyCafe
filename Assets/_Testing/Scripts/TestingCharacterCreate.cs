using CHARACTER;
using UnityEngine;

public class TestingCharacterCreate : MonoBehaviour
{
    void Start()
    {
        RegularCustomer customer = new RegularCustomer("Bob");
        AsilumCustomer bobbi = new AsilumCustomer("Bobbi", Order.Muffin);
        Server noku = new Server("Noku");
    }
}
