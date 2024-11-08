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
        public RectTransform customerContainter => _customerContainer;

        // SERVER ------------------------------------------------------------------------------------
        [SerializeField]
        private RectTransform _serverContainer = null;
        public RectTransform serverContainer => _serverContainer;

        private CharacterConfigSO config => GameSystem.Instance.Config;

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
            characterInfo.name = characterName;

            // we try to load in both the config and the prefab for the character name
            // update: now using casting name, cause we're trying to create a character under a different name
            // and have it use the same config as the original character

            // TODO: add configs
            characterInfo.config = config.GetConfig(characterInfo.name);

            // TODO: add prefabs
            //characterInfo.prefab = GetPrefabForCharacter(characterInfo.castingName);

            // TODO: add character folder paths
            //characterInfo.rootCharacterFolder = FormatCharacterPath(characterRootPath, characterInfo.castingName);

            return characterInfo;
        }


        private Character CreateCharacterFromInfo(CharacterInfo info)
        {
            // TODO: for now, cause the configs aren't being loaded
            if (info.config == null)
            {
                info.config = new CharacterConfigData();
                info.config.Name = info.name;
                info.config.Type = CharacterType.Regular;
            }

            switch (info.config.Type)
            {
                case (CharacterType.Server):
                    {
                        return new Server(info.name, info.config, null);
                    }
                case (CharacterType.Regular):
                    {
                        return new RegularCustomer(info.name, info.config, null);
                    }

                case (CharacterType.Asilum):
                    {
                        // TODO: read the order from the config
                        return new AsilumCustomer(info.name, info.config, null);
                    }
            }
            return null;
        }

        private class CharacterInfo
        {
            public string name = "";
            public CharacterConfigData config = null;
            public GameObject prefab = null;
            public string rootCharacterFolder = "";
        }
    }
}

