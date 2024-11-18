using CHARACTERS;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTER
{
    public abstract class Character
    {
        public string Name;

        public RectTransform Root = null;
        public CharacterConfigData Config;
        public Animator Animator;

        private CharacterManager CharacterManagerInstance => CharacterManager.Instance;

        // TODO: add a render


        protected Character(string name, CharacterConfigData config, GameObject prefab)
        {
            this.Name = name;
            this.Config = config;

            if (prefab != null)
            {
                // instantiate prefab
                GameObject prefabObject = Object.Instantiate(prefab, CharacterManagerInstance.customerContainter);
                prefabObject.name = name;

                // making sure the prefab is active
                prefabObject.SetActive(true);
                // grabs the root object
                Root = prefabObject.GetComponent<RectTransform>();
                // grabs the animator from the children
                Animator = Root.GetComponentInChildren<Animator>();
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