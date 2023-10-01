using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chair : MonoBehaviour {
    public QuickTimeEvent qtEvent;

    void Update() {
        if (qtEvent.state == QuickTimeEvent.State.Fired) {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 90));
        } else {
            transform.rotation = Quaternion.Euler(new Vector3(0, 0, 0));
        }
        transform.position = new Vector3(transform.position.x, transform.position.y, 0);
    }
}
