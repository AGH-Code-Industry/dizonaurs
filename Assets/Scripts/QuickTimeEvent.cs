using EggSystem;
using UnityEngine;
using UnityEngine.UI;

public class QuickTimeEvent : MonoBehaviour {
    public float MinSleepDuration;
    public float MaxSleepDuration;
    public float FixingTime;
    public GameObject imageState;

    public State state = State.Sleeping;
    public State previousState;

    public GameObject ProgressBar;
    private Slider _slider;
    private float timer = 0;
    private float nextSleepDuration = 0;
    private AudioSource _audio;

    public enum State {
        Sleeping,
        Fired,
        Fixing
    }


    void Awake() {
        _audio = GetComponent<AudioSource>();
        _slider = ProgressBar.GetComponent<Slider>();
    }

    void Start() {
        GoToSleep();
        InitializeProgressBar();
    }

    private void InitializeProgressBar() {
        _slider.minValue = 0;
        _slider.maxValue = FixingTime;
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
        previousState = state;
        state = State.Sleeping;
        timer = Time.time;
        if (_audio)
        {
            _audio.Stop();
        }

        if (imageState)
        {
            imageState.SetActive(false);
        }
        nextSleepDuration = GenerateSleepDuration();
        transform.Translate(Vector3.forward * -999);
        _slider.value = 0;
        ProgressBar.SetActive(false);
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
        previousState = state;
        state = State.Fired;
        if (_audio)
        {
            _audio.Play();
        }

        if (imageState)
        {
            imageState.SetActive(true);
        }
        _slider.value = 0;
        ProgressBar.SetActive(false);
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }

    void OnTriggerEnter2D(Collider2D other) {
        GoToFixingState();
    }

    void OnTriggerExit2D(Collider2D other) {
        if (previousState == State.Fired) {
            GoToFiredState();
        } else if (previousState == State.Sleeping) {
            GoToSleep();
        }
    }

    void GoToFixingState() {
        previousState = state;
        state = State.Fixing;
        timer = Time.time;
        ProgressBar.SetActive(true);
    }

    void FixingTick() {
        var fixingDuration = Time.time - timer;
        _slider.value = fixingDuration;
        if (fixingDuration >= FixingTime) {
            GoToSleep();
        }
    }
}
