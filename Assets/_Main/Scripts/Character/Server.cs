using CHARACTERS;
using UnityEngine;

namespace CHARACTER
{
    class Server : Character
    {

        public JobType Job;

        public Server(string name, CharacterConfigData config, GameObject prefab) : base(name, config, prefab)
        {
            Debug.Log($"Spawned Server: [{name}]");
        }

        public enum JobType
        {
            Register,
            Food
        }
    }
}