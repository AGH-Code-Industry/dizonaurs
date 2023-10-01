using EggSystem;
using UnityEngine;

public class QuickTimeEvent : MonoBehaviour {
    public float MinSleepDuration;
    public float MaxSleepDuration;
    public float FixingTime;

    public State state = State.Sleeping;
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
        Debug.Log(nextSleepDuration);
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
        if (Time.time - timer >= FixingTime) {
            GoToSleep();
        }
    }
}
