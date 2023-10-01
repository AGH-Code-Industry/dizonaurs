using System.Collections;
using System.Collections.Generic;
using System.IO;
using App;
using CoinPackage.Debugging;
using EggSystem;
using UnityEngine;
using UnityEngine.UI;

namespace EggSystem
{
    public class Egg : MonoBehaviour
    {
        public Hatcher hatcher;
        public GameObject sliderHolder;
        
        private Slider _slider;
        private EggStatusManager _eggManager;
        private float _currentGrowth = 0;
        private bool _finished = false;
        

        private Animator _anim;
        // Start is called before the first frame update
        void Start()
        {
            _eggManager = EggStatusManager.Instance;
            _anim = GetComponent<Animator>();
            _slider = sliderHolder.GetComponent<Slider>();
            CDebug.Log( _slider, sliderHolder );
            _slider.minValue = 0f;
            _slider.maxValue = DevSettings.Instance.eggSettings.pointsToBorn;
        }

        // Update is called once per frame
        void Update()
        {
            if (_finished)
            {
                return;
            }
            _currentGrowth += _eggManager.CurrentGrowth;
            // TODO: Add points based on dino proximity
            if (Vector2.Distance(transform.position, Player.Instance.transform.position) < DevSettings.Instance.eggSettings.maxDistanceToEgg)
            {
                _currentGrowth += _eggManager.AdditionalGrowth;
            }
            if (_currentGrowth > DevSettings.Instance.eggSettings.pointsToBorn)
            {
                CDebug.Log($"Egg hatched!" % Colorize.Green);
                _finished = true;
                _anim.SetTrigger("eggHatched");
            }else if (_currentGrowth < 0f)
            {
                Destroy(gameObject);
            }

            _slider.value = _currentGrowth;
        }

        void EndLive()
        {
            CDebug.Log("End live");
            hatcher.TellEggHatched();
            Destroy(gameObject);
        }
    }

}
