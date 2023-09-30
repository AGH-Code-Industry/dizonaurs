using UnityEngine;

public class QuickTimeEvent : MonoBehaviour {
    public float MinSleepDuration;
    public float MaxSleepDuration;

    public State state = State.Sleeping;
    private float timer = 0;
    private float nextSleepDuration = 0;
    private SpriteRenderer sprite;


    public enum State {
        Sleeping,
        Fired
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
        GoToSleep();
    }
}
