using System;
using CoinPackage.Debugging;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.Events;

namespace Minigames
{
    public class Switch : MonoBehaviour
    {
        public CableMinigame miniGame;
        private Animator _anim;
        private bool _isSwitched = false;
        private SpriteRenderer _renderer;
        private void Awake()
        {
            _anim = GetComponent<Animator>();
            _renderer = GetComponent<SpriteRenderer>();
        }
        
        void Update () {
            if (Input.touches.Length == 0 || _isSwitched)
            {
                return;
            }

            var touch = Input.touches[0];
            var pos = Camera.main.ScreenToWorldPoint(touch.position);
            pos.z = 0.0f;
            if (_renderer.bounds.Contains(pos))
            {
                HandleClicked();
            }
        }

        public void HandleClicked()
        {
            CDebug.Log("Switch activated");
            if (_isSwitched)
            {
                return;
            }
            _anim.SetBool("enabled", true);
            _isSwitched = true;
        }

        public void FinishClick()
        {
            miniGame.HandleSwitch();
        }
    }
}
