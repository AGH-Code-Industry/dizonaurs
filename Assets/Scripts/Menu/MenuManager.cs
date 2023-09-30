using System.Collections;
using System.Collections.Generic;
using App;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        // Start is called before the first frame update
        void Start()
        {
            SceneManager.LoadScene(DevSettings.Instance.appSettings.gameSceneName);
        }
    }
}