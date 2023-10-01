using EggSystem;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour {
    public float MinSleepDuration;
    public float MaxSleepDuration;
    public float FixingTime;

    public State state = State.Sleeping;

    public Slider ProgressBar;
    private float timer = 0;
    private float nextSleepDuration = 0;
    private SpriteRenderer sprite;
    private AudioSource _audio;

    public enum State {
        Sleeping,
        Fired,
        Fixing
    }


    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
        _audio = GetComponent<AudioSource>();
    }

    void Start() {
        GoToSleep();
        InitializeProgressBar();
    }

    private void InitializeProgressBar() {
        ProgressBar.minValue = 0;
        ProgressBar.maxValue = FixingTime;
        ProgressBar.value = 0;

    }

    void Update() {
        switch (state) {
            case State.Sleeping:
                SleepTick();
                break;
            case State.Fixing:
                FixingTick();
                break;
        }
    }

    private void GoToSleep() {
        state = State.Sleeping;
        timer = Time.time;
        if (_audio)
        {
            _audio.Stop();
        }
        nextSleepDuration = GenerateSleepDuration();
        transform.Translate(Vector3.forward * -999);
        EggStatusManager.Instance.decreateDisturbances();
    }

    private float GenerateSleepDuration() {
        return Random.value * (MaxSleepDuration - MinSleepDuration) + MinSleepDuration;
    }

    private void SleepTick() {
        if (Time.time - timer >= nextSleepDuration) {
            GoToFiredState();
        }
    }

    private void GoToFiredState() {
        state = State.Fired;
        if (_audio)
        {
            _audio.Play();
        }
        EggStatusManager.Instance.Disturbances += 1;
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        GoToFixingState();
    }

    void OnTriggerExit2D(Collider2D other) {
        GoToSleep();
    }

    void GoToFixingState() {
        state = State.Fixing;
        timer = Time.time;
    }

    void FixingTick() {
        var fixingDuration = Time.time - timer;
        ProgressBar.value = fixingDuration;
        if (fixingDuration >= FixingTime) {
            GoToSleep();
        }
    }
}
