using CHARACTERS;
using System.Collections.Generic;
using UnityEngine;

namespace CHARACTER
{
    public class CharacterManager : MonoBehaviour
    {
        public static CharacterManager Instance { get; private set; }
        private readonly Dictionary<string, Character> Characters = new Dictionary<string, Character>();

        // give the character container through the unity editor
        // CUSTOMER ----------------------------------------------------------------------------------
        [SerializeField]
        private RectTransform _customerContainer = null;
        public RectTransform CustomerContainter => _customerContainer;

        // SERVER ------------------------------------------------------------------------------------
        [SerializeField]
        private RectTransform _serverContainer = null;
        public RectTransform ServerContainer => _serverContainer;

        private CharacterConfigSO Config => GameSystem.Instance.Config;

        private void Awake()
        {
            Instance = this;
        }

        public Character CreateCharacter(string characterName)
        {
            if (Characters.ContainsKey(characterName.ToLower()))
            {
                Debug.LogWarning($"A character called - '{characterName}' already exists.");
                return null;
            }

            CharacterInfo characterInfo = GetCharacterInfo(characterName);
            Character character = CreateCharacterFromInfo(characterInfo);

            Characters.Add(characterName.ToLower(), character);

            return character;
        }

        private CharacterInfo GetCharacterInfo(string characterName)
        {
            CharacterInfo characterInfo = new CharacterInfo();
            characterInfo.Name = characterName;

            // we try to load in both the config and the prefab for the character name
            // update: now using casting name, cause we're trying to create a character under a different name
            // and have it use the same config as the original character

            // TODO: add configs
            characterInfo.Config = Config.GetConfig(characterInfo.Name);

            // TODO: add prefabs
            characterInfo.Prefab = GetPrefabForCharacter(characterInfo.Name, characterInfo.Config.Type);

            // TODO: add character folder paths
            //characterInfo.rootCharacterFolder = FormatCharacterPath(characterRootPath, characterInfo.castingName);

            return characterInfo;
        }


        private Character CreateCharacterFromInfo(CharacterInfo info)
        {
            // TODO: for now, cause the configs aren't being loaded
            if (info.Config == null)
            {
                info.Config = new CharacterConfigData();
                info.Config.Name = info.Name;
                info.Config.Type = CharacterType.Regular;
            }

            switch (info.Config.Type)
            {
                case (CharacterType.Server):
                    {
                        return new Server(info.Name, info.Config, info.Prefab);
                    }
                case (CharacterType.Regular):
                    {
                        return new RegularCustomer(info.Name, info.Config, info.Prefab);
                    }

                case (CharacterType.Asilum):
                    {
                        // TODO: read the order from the config
                        return new AsilumCustomer(info.Name, info.Config, info.Prefab);
                    }
            }
            return null;
        }

        private GameObject GetPrefabForCharacter(string characterName, CharacterType type)
        {
            string folderPath = "Characters/";
            switch (type)
            {
                case CharacterType.Server:
                    folderPath += $"Servers/{characterName}";
                    break;
                case CharacterType.Regular:
                    // TODO: pick some prefab at random
                    folderPath += "Customers/Regulars/Customer_1";
                    break;
                case CharacterType.Asilum:
                    folderPath += $"Customers/Asilum/{characterName}";
                    break;
            }

            GameObject prefab = Resources.Load<GameObject>(folderPath);
            if (prefab != null)
            {
                return prefab;
            }

            Debug.LogWarning($"[{characterName}] not found.");
            return null;
        }

        private class CharacterInfo
        {
            public string Name = "";
            public CharacterConfigData Config = null;
            public GameObject Prefab = null;
            public string RootCharacterFolder = "";
        }
    }
}

