using System.Collections;
using UnityEngine;
using UnityEngine.UI;

namespace CHARACTER
{
    // Contains data and functions to a layer composing a sprite character
    public class CharacterRender
    {
        // the image being shown
        public Image Renderer { get; private set; } = null;

        // pointer to the canvas group applied to whatever the current renderer is
        public CanvasGroup CurrentCanvasGroup => Renderer.GetComponent<CanvasGroup>();

        // reference to the character manager - we use it to manage coroutines from here
        private CharacterManager CharacterManager => CharacterManager.Instance;

        // coroutine to fade in/out the layers
        private Coroutine coroutineTransitioningLayer = null;
        // keeping track of characters actions - is it transitioning?
        public bool IsTransitioningLayer => coroutineTransitioningLayer != null;
        // ----------------------------------------------------------------------------------------------------------

        public CharacterRender(Image defaultRenderer)
        {
            Renderer = defaultRenderer;
        }

        public void SetSprite(Sprite sprite)
        {
            Renderer.sprite = sprite;
        }

        public Coroutine TransitionSprite(Sprite sprite, float speed = 1f)
        {
            // if we're already using this sprite, don't do anything
            if (sprite == Renderer.sprite)
            {
                return null;
            }

            if (IsTransitioningLayer)
            {
                CharacterManager.StopCoroutine(coroutineTransitioningLayer);
            }

            coroutineTransitioningLayer = CharacterManager.StartCoroutine(TransitioningSprite(sprite));
            return coroutineTransitioningLayer;
        }

        private IEnumerator TransitioningSprite(Sprite sprite)
        {
            Image newRenrerer = CreateRenderer(Renderer.transform.parent);
            newRenrerer.sprite = sprite;
            return null;
        }

        private Image CreateRenderer(Transform parent)
        {
            // create a new renderer and add the old one to the list of old renderers
            Image newRenderer = Object.Instantiate(Renderer, parent);

            // assign the same name to the image renderer so we don't end up with a bunch of "Image(Clone)"
            newRenderer.name = Renderer.name;
            Renderer = newRenderer;
            Renderer.gameObject.SetActive(true);
            CurrentCanvasGroup.alpha = 0f;

            return newRenderer;
        }
    }
}