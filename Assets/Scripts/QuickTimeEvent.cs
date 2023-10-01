using UnityEngine;

public class QuickTimeEvent : MonoBehaviour {
    public float MinSleepDuration;
    public float MaxSleepDuration;
    public float FixingTime;

    public State state = State.Sleeping;
    private float timer = 0;
    private float nextSleepDuration = 0;
    private SpriteRenderer sprite;


    public enum State {
        Sleeping,
        Fired,
        Fixing
    }


    void Awake() {
        sprite = GetComponent<SpriteRenderer>();
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
        nextSleepDuration = GenerateSleepDuration();
        Debug.Log(nextSleepDuration);
        sprite.enabled = false;
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
        sprite.enabled = true;
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
