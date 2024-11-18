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

        // Coroutines -----------------------------------------------------------------------------------
        protected Coroutine RevealingCoroutine;
        protected Coroutine HidingCoroutine;
        protected Coroutine MovingCoroutine;

        public bool IsReavealing => RevealingCoroutine != null;
        public bool IsHiding => HidingCoroutine != null;
        public bool IsMoving => MovingCoroutine != null;
        // ----------------------------------------------------------------------------------------------

        private CharacterManager CharacterManagerInstance => CharacterManager.Instance;

        protected Character(string name, CharacterConfigData config, GameObject prefab)
        {
            this.Name = name;
            this.Config = config;

            if (prefab != null)
            {
                // instantiate prefab
                GameObject prefabObject = Object.Instantiate(prefab, CharacterManagerInstance.CustomerContainter);
                prefabObject.name = name;

                // making sure the prefab is active
                prefabObject.SetActive(true);
                // grabs the root object
                Root = prefabObject.GetComponent<RectTransform>();
                // grabs the animator from the children
                Animator = Root.GetComponentInChildren<Animator>();

                if (Root != null)
                {
                    Debug.Log("Found Root");
                }

                if (Animator != null)
                {
                    Debug.Log("Found Animator");
                }
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