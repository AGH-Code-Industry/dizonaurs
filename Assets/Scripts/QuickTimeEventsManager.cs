using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuickTimeEventsManager : MonoBehaviour {
    public QuickTimeEventsManager Instance = null;

    private List<QuickTimeEvent> qtEvents = new List<QuickTimeEvent>();

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        foreach (Transform child in transform) {
            qtEvents.Add(child.gameObject.GetComponent<QuickTimeEvent>());
        }
    }

    int firedQuickTimeEvents() {
        return qtEvents
            .FindAll(qtEvent => qtEvent.state == QuickTimeEvent.State.Fired)
            .Count;
    }
}

        
        