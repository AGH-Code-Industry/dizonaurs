using UnityEngine;

namespace EggSystem
{
    [CreateAssetMenu(fileName = "EggSystemSettings", menuName = "Settings/EggSystemSettings")]
    public class EggSystemSettingsDefinition : ScriptableObject
    {
        public int pointsToBorn = 1000;
        public int normalGrowth = 3;
        public int additionalGrowth = 3;

    }
}