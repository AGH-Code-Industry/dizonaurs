using System;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class UIManager : MonoBehaviour
    {
        [SerializeField] private GameObject goToGarden;
        [SerializeField] private GameObject goToLevel;

        public Transform cameraa;

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
            goToGarden.SetActive(false);
            goToLevel.SetActive(true);
            cameraa.position = new Vector3(63f, cameraa.position.y, cameraa.position.z);
        }

        public void GoToLevel()
        {
            goToLevel.SetActive(false);
            goToGarden.SetActive(true);
            cameraa.position = new Vector3(-6.2f, cameraa.position.y, cameraa.position.z);
        }
    }
}