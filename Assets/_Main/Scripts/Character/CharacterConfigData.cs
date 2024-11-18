using CHARACTER;

namespace CHARACTERS
{
    // to be seen in the inspector
    [System.Serializable]
    public class CharacterConfigData
    {
        public string Name;

        public CharacterType Type;

        public Order Order;

        // due to this class being used in scriptable objects, we're providing a copy of the date as to not mess with the original scriptable object
        // Copy is just a utility function
        public CharacterConfigData Copy()
        {
            CharacterConfigData configData = new CharacterConfigData();
            configData.Name = Name;
            configData.Type = Type;
            configData.Order = Order;
            return configData;
        }

        public static CharacterConfigData CharacterConfigDataDefault
        {
            get
            {
                CharacterConfigData characterConfigData = new CharacterConfigData();
                characterConfigData.Name = "";
                characterConfigData.Type = CharacterType.Regular;
                characterConfigData.Order = Order.Muffin;
                return characterConfigData;
            }
        }
    }
}