using UnityEngine;

namespace EggSystem
{
    [CreateAssetMenu(fileName = "EggSystemSettings", menuName = "Settings/EggSystemSettings")]
    public class EggSystemSettingsDefinition : ScriptableObject
    {
        public int pointsToBorn = 1000;
        public int normalGrowth = 3;
        public int additionalGrowth = 3;
        public float timeForNewEggToHatch = 2.0f;
        public float timeForHatchVariation = 0.5f;
        public float maxDistanceToEgg = 0.5f;
    }
}