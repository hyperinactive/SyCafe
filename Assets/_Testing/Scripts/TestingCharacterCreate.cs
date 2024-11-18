using CHARACTER;
using System.Collections;
using UnityEngine;

public class TestingCharacterCreate : MonoBehaviour
{
    void Start()
    {
        // CreateCharacterClass();
        StartCoroutine(CreateCharacterViaManager());
    }

    void CreateCharacterClass()
    {
        //RegularCustomer customer = new RegularCustomer("Bob");
        //AsilumCustomer bobbi = new AsilumCustomer("Bobbi", Order.Muffin);
        //Server noku = new Server("Noku");
    }

    IEnumerator CreateCharacterViaManager()
    {
        var noku = CharacterManager.Instance.CreateCharacter("Noku");
        var syrex = CharacterManager.Instance.CreateCharacter("Syrex");
        var hyper = CharacterManager.Instance.CreateCharacter("Hyper");
        var regular = CharacterManager.Instance.CreateCharacter("Regular");
        regular.SetPosition(new Vector2(-1f, -1f));

        noku.SetPosition(new Vector2(0.5f, 0.45f));
        syrex.SetPosition(new Vector2(0.65f, 0.45f));
        hyper.SetPosition(new Vector2(0.9f, 0.15f));

        yield return new WaitForSeconds(2f);
        hyper.MoveToPosition(new Vector2(0.65f, 0.15f));
        yield return new WaitForSeconds(1f);
        regular.SetPosition(new Vector2(0.9f, 0.15f));
        yield return regular.Show();

        yield return null;
    }
}
