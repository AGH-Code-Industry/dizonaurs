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

        public void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("Tried to override singleton istance");
            }

            Instance = this;
        }

        public void CreateNewChildLevelHigher(int newLevel, Vector2 position)
        {
            try
            {
                Instantiate(childPrefabs[newLevel], position, Quaternion.identity);
            }
            catch (Exception e)
            {
                CDebug.Log("Max dino level.");
            }
            
        }
    }
}
