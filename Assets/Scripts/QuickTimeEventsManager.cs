using System.Collections;
using System.Collections.Generic;
using Minigames;
using UnityEngine;

public class QuickTimeEventsManager : MonoBehaviour {
    static public QuickTimeEventsManager Instance = null;

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

    public int firedQuickTimeEvents() {
        return qtEvents
            .FindAll(qtEvent => qtEvent.state == QuickTimeEvent.State.Fired || qtEvent.state == QuickTimeEvent.State.Fixing)
            .Count;
    }
}

        
        