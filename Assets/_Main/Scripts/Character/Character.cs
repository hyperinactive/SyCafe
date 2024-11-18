using CHARACTERS;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTER
{
    public abstract class Character
    {
        public string Name;

        public RectTransform Root = null;
        public CharacterConfigData Config;
        public Animator Animator = null;

        // Coroutines -----------------------------------------------------------------------------------
        protected Coroutine RevealingCoroutine;
        protected Coroutine HidingCoroutine;
        protected Coroutine MovingCoroutine;

        public bool IsRevealing => RevealingCoroutine != null;
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
                RectTransform targetContainer = null;

                switch (config.Type)
                {
                    case CharacterType.Server:
                        targetContainer = this.CharacterManagerInstance.ServerContainer;
                        break;
                    case CharacterType.Regular:
                        targetContainer = this.CharacterManagerInstance.CustomerContainter;
                        break;
                    case CharacterType.Asilum:
                        targetContainer = this.CharacterManagerInstance.CustomerContainter;
                        break;
                }

                // instantiate prefab
                GameObject prefabObject = Object.Instantiate(prefab, targetContainer);
                prefabObject.name = this.Name;

                // making sure the prefab is active
                prefabObject.SetActive(true);
                // grabs the root object
                this.Root = prefabObject.GetComponent<RectTransform>();
                // grabs the animator from the children
                this.Animator = this.Root.GetComponentInChildren<Animator>();
            }
        }

        // making the entrance and exit coroutines virtual so that we can override them in the derived classes
        // making it a Coroutine so we can get the loop and know when it's done
        public virtual Coroutine Show()
        {
            if (this.IsRevealing)
            {
                return this.RevealingCoroutine;
            }

            if (this.IsHiding)
            {
                this.CharacterManagerInstance.StopCoroutine(HidingCoroutine);
            }

            this.RevealingCoroutine = this.CharacterManagerInstance.StartCoroutine(ShowingOrHiding(true));
            return this.RevealingCoroutine;
        }

        public virtual Coroutine Hide()
        {
            if (this.IsHiding)
            {
                return this.HidingCoroutine;
            }

            if (this.IsRevealing)
            {
                this.CharacterManagerInstance.StopCoroutine(RevealingCoroutine);
            }

            this.RevealingCoroutine = this.CharacterManagerInstance.StartCoroutine(ShowingOrHiding(false));
            return this.HidingCoroutine;
        }

        // since this is loopig logic we need to know if we're already showing or hiding
        // we need a way to cancel them out
        public virtual IEnumerator ShowingOrHiding(bool show)
        {
            yield return null;
        }

        // we'll be operating within the UI space, so we can set the position of the character
        // we must move the character based on the individual height and width of the render - RectTransform
        // position cannot be set directly, we need to set the anchoredPosition
        public virtual void SetPosition(Vector2 position)
        {
            if (this.Root == null)
            {
                return;
            }

            (Vector2 minAnchorTarget, Vector2 maxAnchorTarget) = this.ConvertUITargetPositionToRelativeCharacterAnchorTarget(position);
            this.Root.anchorMin = minAnchorTarget;
            this.Root.anchorMax = maxAnchorTarget;
        }

        protected (Vector2, Vector2) ConvertUITargetPositionToRelativeCharacterAnchorTarget(Vector2 position)
        {
            // anchorMax - position of the top right
            // anchorMin - position of the bottom left
            Vector2 padding = this.Root.anchorMax - this.Root.anchorMin;

            float maxX = 1f - padding.x;
            float maxY = 1f - padding.y;

            Vector2 minAnchorTarget = new Vector2(maxX * position.x, maxY * position.y);
            Vector2 maxAnchorTarget = minAnchorTarget + padding;

            return (minAnchorTarget, maxAnchorTarget);
        }

        public virtual Coroutine MoveToPosition(Vector2 position, float speed = 2f, bool smooth = false)
        {
            if (this.IsMoving)
            {
                this.CharacterManagerInstance.StopCoroutine(this.MovingCoroutine);
            }

            this.CharacterManagerInstance.StartCoroutine(this.MovingToPosition(position, speed, smooth));
            return this.MovingCoroutine;
        }

        public IEnumerator MovingToPosition(Vector2 position, float speed, bool smooth)
        {
            (Vector2 minAnchorTarget, Vector2 maxAnchorTarget) = this.ConvertUITargetPositionToRelativeCharacterAnchorTarget(position);
            Vector2 padding = this.Root.anchorMax - this.Root.anchorMin;

            while (this.Root.anchorMin != minAnchorTarget || this.Root.anchorMax != maxAnchorTarget)
            {
                if (smooth)
                {
                    // Lerp has a falloff range and needs more time to complete
                    this.Root.anchorMin = Vector2.Lerp(this.Root.anchorMin, minAnchorTarget, speed * Time.deltaTime * 2f);
                }
                else
                {
                    this.Root.anchorMin = Vector2.MoveTowards(this.Root.anchorMin, minAnchorTarget, speed * Time.deltaTime * 0.35f);
                }

                this.Root.anchorMax = this.Root.anchorMin + padding;

                if (smooth && Vector2.Distance(this.Root.anchorMin, minAnchorTarget) < 0.01f)
                {
                    this.Root.anchorMin = minAnchorTarget;
                    this.Root.anchorMax = maxAnchorTarget;
                    break;
                }

                yield return null;
            }

            Debug.Log("Done moving");
            this.MovingCoroutine = null;
        }
    }

    public enum CharacterType
    {
        Regular,
        Asilum,
        Server
    }
}