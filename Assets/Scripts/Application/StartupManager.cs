using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartupManager : MonoBehaviour
{
    void Start()
    {
        // All non destoryable are now loaded, go to menu
        SceneManager.LoadScene("Scenes/Menu");
    }
}
