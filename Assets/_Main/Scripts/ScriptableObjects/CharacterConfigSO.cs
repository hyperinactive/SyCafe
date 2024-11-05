using CHARACTERS;
using UnityEngine;

namespace CHARACTER
{
    // this creates a menu item in the editor itself! - so cool
    // creates an asset which can be populated with data
    [CreateAssetMenu(fileName = "Character Configuration Asset", menuName = "Character Configuration Asset")]
    public class CharacterConfigSO : ScriptableObject
    {
        public CharacterConfigData[] characters;

        public CharacterConfigData GetConfig(string characterName)
        {
            characterName = characterName.ToLower();

            for (int i = 0; i < characters.Length; i++)
            {
                CharacterConfigData data = characters[i];

                if (string.Equals(characterName, characters[i].Name))
                {
                    // returning data cause of this reason
                    // when returning values and working with scriptable objects we have to keep in mind persistance of scriptable object data
                    // we don't want to change the original data
                    return data.Copy();
                }
            }

            // either get a match or return the default config
            return CharacterConfigData.CharacterConfigDataDefault;
        }
    }
}