using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Player : MonoBehaviour {
    void Update() {
        var touches = Input.touches;
        if (touches.Count() == 0) {
            return;
        }
        var touch = touches[0];
        var dest = Camera.main.ScreenToWorldPoint(touch.position);
        dest.z = 0;
        transform.position = dest;
    }
}
