using System;
using App;
using UnityEngine;

namespace EggSystem
{
    public class EggStatusManager : MonoBehaviour
    {
        public static EggStatusManager Instance;
        
        
        public float CurrentGrowthRaw { get; set; }
        public float CurrentGrowth { get; set; }
        public float AdditionalGrowth { get; set; }
        public int Disturbances { get; set; } = 0;

        private void Awake()
        {
            if (Instance != null)
            {
                throw new Exception("Tried to overwrite singleton");
            }
            Instance = this;
            
        }

        private void Update()
        {
            CalculateGrowth();
        }

        private void CalculateGrowth()
        {
            CurrentGrowthRaw = DevSettings.Instance.eggSettings.normalGrowth - Disturbances;
            CurrentGrowthRaw = Math.Clamp(CurrentGrowthRaw, 0, 100);
            CurrentGrowth = CurrentGrowthRaw * Time.deltaTime;
            AdditionalGrowth = (DevSettings.Instance.eggSettings.additionalGrowth) * Time.deltaTime;
        }
    }
}