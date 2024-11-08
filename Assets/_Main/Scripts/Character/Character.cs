using CHARACTERS;
using UnityEngine;

namespace CHARACTER
{
    public abstract class Character
    {
        public string name;

        public RectTransform root = null;
        public CharacterConfigData config;
        public Animator animator;

        private CharacterManager characterManagerInstance => CharacterManager.Instance;

        // TODO: add a render

        protected Character(string name, CharacterConfigData config, GameObject prefab)
        {
            this.name = name;
            this.config = config;

            if (prefab != null)
            {
                // instantiate prefab
                GameObject prefabObject = Object.Instantiate(prefab, characterManagerInstance.customerContainter);
                prefabObject.name = name;

                // making sure the prefab is active
                prefabObject.SetActive(true);
                // grabs the root object
                root = prefabObject.GetComponent<RectTransform>();
                // grabs the animator from the children
                animator = root.GetComponentInChildren<Animator>();
            }
        }
    }

    public enum CharacterType
    {
        Regular,
        Asilum,
        Server
    }
}