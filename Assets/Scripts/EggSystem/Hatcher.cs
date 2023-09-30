using System;
using System.Collections;
using App;
using UnityEngine;

namespace EggSystem
{
    public class Hatcher : MonoBehaviour
    {
        public GameObject eggPrefab;
        public Transform eggPlace;

        private void Start()
        {
            CreateNewEgg();
        }

        public void TellEggHatched()
        {
            StartCoroutine(WaitForNewEgg(DevSettings.Instance.eggSettings.timeForNewEggToHatch));
        }
        
        private void CreateNewEgg()
        {
            var newEgg = Instantiate(eggPrefab, eggPlace.position, Quaternion.identity);
            var eggScript = newEgg.GetComponent<Egg>();
            eggScript.hatcher = this;
        }

        IEnumerator WaitForNewEgg(float time)
        {
            yield return new WaitForSeconds(time);
            CreateNewEgg();
        }
    }
}