using UnityEngine;

namespace App
{
    [CreateAssetMenu(fileName = "AppSettings", menuName = "Settings/AppSettings")]
    public class AppSettingsDefinition : ScriptableObject
    {
        public string gameSceneName = "Game";
    }
}