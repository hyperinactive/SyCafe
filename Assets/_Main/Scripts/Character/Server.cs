using UnityEngine;

namespace CHARACTER
{
    class Server : Character
    {

        public JobType Job;

        public Server(string name) : base(name)
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