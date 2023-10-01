using System;
using System.Collections.Generic;
using CoinPackage.Debugging;
using UnityEngine;

namespace Garden
{
    public class ChildManager : MonoBehaviour
    {
        public static ChildManager Instance;
        public GameObject[] childPrefabs;

        private AudioSource _audio;

        public void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("Tried to override singleton istance");
            }

            Instance = this;
            _audio = GetComponent<AudioSource>();
        }

        public void CreateNewChildLevelHigher(int newLevel, Vector2 position)
        {
            try
            {
                _audio.Play();
                Instantiate(childPrefabs[newLevel], position, Quaternion.identity);
            }
            catch (Exception e)
            {
                CDebug.Log("Max dino level.");
            }
            
        }
    }
}
