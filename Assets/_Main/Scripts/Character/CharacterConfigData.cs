namespace CHARACTERS
{
    // to be seen in the inspector
    [System.Serializable]
    public class CharacterConfigData
    {
        public string name;

        // due to this class being used in scriptable objects, we're providing a copy of the date as to not mess with the original scriptable object
        // Copy is just a utility function
        public CharacterConfigData Copy()
        {
            CharacterConfigData configData = new CharacterConfigData();
            configData.name = name;
            return configData;
        }

        public static CharacterConfigData CharacterConfigDataDefault
        {
            get
            {
                CharacterConfigData characterConfigData = new CharacterConfigData();
                characterConfigData.name = "";
                return characterConfigData;
            }
        }
    }
}