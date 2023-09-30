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
        // Start is called before the first frame update
        void Start()
        {
            _eggManager = EggStatusManager.Instance;
        }

        // Update is called once per frame
        void Update()
        {
            _currentGrowth += _eggManager.CurrentGrowth;
            // TODO: Add points based on dino proximity
            if (_currentGrowth > DevSettings.Instance.eggSettings.pointsToBorn)
            {
                CDebug.Log($"Egg hatched!" % Colorize.Green);
                hatcher.TellEggHatched();
                Destroy(gameObject);
            }
        }
    }

}
