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
        public bool IsBroken = false;

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
            if (IsBroken)
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
            IsBroken = true;
            // _renderer.color = Color.red;
            particles.SetActive(true);
            _audio.Play();
        }

        public void Repair()
        {
            particles.SetActive(false);
            // _renderer.color = Color.white;
            CalcNextActivationTime();
            IsBroken = false;
            _audio.Stop();
        }

        private void InitGame()
        {
            var game = Instantiate(gamePrefab, new Vector2(-6.45f, -3.55f), Quaternion.identity);
            game.GetComponent<CableMinigame>().controller = this;
        }

        private void OnTriggerEnter2D(Collider2D col)
        {
            if (IsBroken)
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