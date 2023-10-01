using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject goToGarden;
        [SerializeField] private GameObject goToLevel;

        public GameObject level;
        public GameObject garden;

        private Button _goToGardenButton;
        private Button _goToLevelButton;

        private void Awake()
        {
            _goToGardenButton = goToGarden.GetComponent<Button>();
            _goToLevelButton = goToLevel.GetComponent<Button>();
            _goToGardenButton.onClick.AddListener(GoToGarden);
            _goToLevelButton.onClick.AddListener(GoToLevel);
        }

        public void GoToGarden()
        {
            level.SetActive(false);
            garden.SetActive(true);
            goToGarden.SetActive(false);
            goToLevel.SetActive(true);
        }

        public void GoToLevel()
        {
            level.SetActive(true);
            garden.SetActive(false);
            goToLevel.SetActive(false);
            goToGarden.SetActive(true);
        }
    }
}