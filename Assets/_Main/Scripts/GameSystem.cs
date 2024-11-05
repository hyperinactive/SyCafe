using CHARACTER;
using UnityEngine;

public class GameSystem : MonoBehaviour
{
    // 2. so we serialize this private variable while the public one references it
    [SerializeField]
    private CharacterConfigSO _config;

    // 1. not something we want anything to edit and we can't use the private keyword cause it won't serialize with the inspector
    public CharacterConfigSO Config => _config;

    private bool isInitialized = false;

    public static GameSystem Instance { get; private set; }


    private void Initialize()
    {
        if (isInitialized)
        {
            return;
        }
    }

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            Initialize();
        }
        else
        {
            // Destroy the game object in the scene
            DestroyImmediate(Instance);
        }
    }
}