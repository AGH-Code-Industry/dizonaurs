using System.Collections;
using System.Collections.Generic;
using App;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Menu
{
    public class MenuManager : MonoBehaviour
    {
        public Button playButton;
        public Button quitButton;
        // Start is called before the first frame update
        void Start()
        {
            playButton.onClick.AddListener(OnPlayClicked);
            quitButton.onClick.AddListener((() => Application.Quit()));
        }

        void OnPlayClicked()
        {
            SceneManager.LoadScene("Game");
        }
    }
}
