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
        var syrex = CharacterManager.Instance.CreateCharacter("Syrex");
        var hyper = CharacterManager.Instance.CreateCharacter("Hyper");
        var regular = CharacterManager.Instance.CreateCharacter("Regular");
        Debug.Log(noku);
    }
}
