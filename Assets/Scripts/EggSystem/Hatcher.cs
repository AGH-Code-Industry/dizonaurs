using System;
using System.Collections;
using App;
using UnityEngine;
using Random = UnityEngine.Random;

namespace EggSystem
{
    public class Hatcher : MonoBehaviour
    {
        public GameObject eggPrefab;
        public Transform eggPlace;
        public Transform parent;
        public Transform parentForNewChild;
        public GameObject childPrefab;

        private void Start()
        {
            CreateNewEgg();
        }

        public void TellEggHatched()
        {
            var pos = parentForNewChild.position + new Vector3(Random.Range(-5f, 5f), Random.Range(-5f, 5f), 0f);
            var child = Instantiate(childPrefab, pos, Quaternion.identity,
                parentForNewChild);
            // child.SetActive(false);
            var time = Random.Range(-DevSettings.Instance.eggSettings.timeForHatchVariation,
                DevSettings.Instance.eggSettings.timeForHatchVariation);
            StartCoroutine(WaitForNewEgg(DevSettings.Instance.eggSettings.timeForNewEggToHatch + time));
        }
        
        private void CreateNewEgg()
        {
            var newEgg = Instantiate(eggPrefab, eggPlace.position, Quaternion.identity, parent);
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