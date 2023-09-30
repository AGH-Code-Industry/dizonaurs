using System.Collections;
using System.Collections.Generic;
using System.IO;
using App;
using CoinPackage.Debugging;
using EggSystem;
using UnityEngine;

namespace EggSystem
{
    public class Egg : MonoBehaviour
    {
        public Hatcher hatcher;
        private EggStatusManager _eggManager;
        private float _currentGrowth = 0;
        private bool _finished = false;

        private Animator _anim;
        // Start is called before the first frame update
        void Start()
        {
            _eggManager = EggStatusManager.Instance;
            _anim = GetComponent<Animator>();
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
            if (_currentGrowth > DevSettings.Instance.eggSettings.pointsToBorn)
            {
                CDebug.Log($"Egg hatched!" % Colorize.Green);
                _finished = true;
                _anim.SetTrigger("eggHatched");
            }
        }

        void EndLive()
        {
            CDebug.Log("End live");
            hatcher.TellEggHatched();
            Destroy(gameObject);
        }
    }

}
