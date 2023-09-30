using System;
using EggSystem;
using UnityEngine;

namespace App
{
    public class DevSettings : MonoBehaviour
    {
        public static DevSettings Instance;
        
        public AppSettingsDefinition appSettings;
        public EggSystemSettingsDefinition eggSettings;

        private void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("Tried to override singleton");
            }

            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
}