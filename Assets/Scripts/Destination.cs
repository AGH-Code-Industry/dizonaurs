using UnityEngine;

[RequireComponent(typeof(CircleCollider2D))]
public class Destination : MonoBehaviour {
    private CircleCollider2D collider;
    private Camera camera;
    public Transform destination;

    void Start() {
        collider = GetComponent<CircleCollider2D>();
        camera = Camera.main;
    }

    void Update() {
        CheckTouch();
    }

    private void CheckTouch() {
        var touches = Input.touches;
        if (touches.Length == 0) {
            return;
        }
        var touch = touches[0];
        var point = camera.ScreenToWorldPoint(touch.position);
        point.z = 0;
        if (collider.bounds.Contains(point)) {
            if (destination)
            {
                Player.Instance.moveTo.setGoal(destination);
            }
            else
            {
                Player.Instance.moveTo.setGoal(transform);
            }
            
        }
    }
}
