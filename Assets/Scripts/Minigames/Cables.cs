using System;
using EggSystem;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Minigames
{
    public class Cables : MonoBehaviour
    {
        public GameObject gamePrefab;
        public float timeBetweenActivations;
        [Range(0f, 1f)]
        public float deviationFactor;

        public GameObject particles;

        private SpriteRenderer _renderer;
        private AudioSource _audio;

        private float _lastActivation;
        private float _nextActivationTime;
        private float _deviation;
        private bool _isBroken = false;

        private void Awake()
        {
            _renderer = GetComponent<SpriteRenderer>();
            _audio = GetComponent<AudioSource>();
            _deviation = timeBetweenActivations * deviationFactor;
            CalcNextActivationTime();
            particles.SetActive(false);
        }

        private void Update()
        {
            if (_isBroken)
            {
                return;
            }
            if (Time.time > _nextActivationTime)
            {
                Break();
            }
        }

        private void Break()
        {
            EggStatusManager.Instance.Disturbances += 1;
            _isBroken = true;
            // _renderer.color = Color.red;
            particles.SetActive(true);
            _audio.Play();
        }

        public void Repair()
        {
            EggStatusManager.Instance.Disturbances -= 1;
            particles.SetActive(false);
            // _renderer.color = Color.white;
            CalcNextActivationTime();
            _isBroken = false;
            _audio.Stop();
        }

        private void InitGame()
        {
            var game = Instantiate(gamePrefab, new Vector2(-6.3f, -2.6f), Quaternion.identity);
            game.GetComponent<CableMinigame>().controller = this;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (_isBroken)
            {
                InitGame();
            }
        }

        private void CalcNextActivationTime()
        {
            _nextActivationTime = Time.time + timeBetweenActivations + Random.Range(-_deviation, _deviation);
        }
    }
}