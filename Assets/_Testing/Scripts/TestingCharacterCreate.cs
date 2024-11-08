using CHARACTER;
using UnityEngine;

public class TestingCharacterCreate : MonoBehaviour
{
    void Start()
    {
        // CreateCharacterClass();
        CreateCharacterViaManager();
    }

    void CreateCharacterClass()
    {
        //RegularCustomer customer = new RegularCustomer("Bob");
        //AsilumCustomer bobbi = new AsilumCustomer("Bobbi", Order.Muffin);
        //Server noku = new Server("Noku");
    }

    void CreateCharacterViaManager()
    {
        var noku = CharacterManager.Instance.CreateCharacter("Noku");
        Debug.Log(noku);
    }
}
