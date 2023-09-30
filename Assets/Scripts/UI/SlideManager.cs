using System;
using EggSystem;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class SlideManager : MonoBehaviour
    {
        
        private Slider _slider;

        private void Awake()
        {
            _slider = GetComponent<Slider>();
        }

        private void Update()
        {
            _slider.value = EggStatusManager.Instance.CurrentGrowthRaw;
        }
    }
}