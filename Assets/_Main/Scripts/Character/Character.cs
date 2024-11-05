using CHARACTERS;

namespace CHARACTER
{
    public abstract class Character
    {
        public string Name;

        // TODO: add a render

        protected Character(string name)
        {
            Name = name;
        }
    }

    public enum CharacterType
    {
        Regular,
        Asilum,
        Server
    }
}