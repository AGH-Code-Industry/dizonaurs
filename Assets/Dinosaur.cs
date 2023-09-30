using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Dinosaur : MonoBehaviour
{
    // Start is called before the first frame update
    public static Dinosaur Instance = null;
    public float speed = 1;
    private Vector3 destination = new Vector3(3, 3, 0);
    private float detectionRadius = 0.4f;


    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        
    }

    // Update is called once per frame
    void Update() {
        UpdateDestination();
        MoveToDestination();
    }

    void UpdateDestination() {
        var touches = Input.touches;
        if (touches.Count() == 0) {
            return;
        }
        var touch = touches[0];
        destination = Camera.main.ScreenToWorldPoint(touch.position);
    }

    void MoveToDestination() {
        if (isAtDestination()) {
            Debug.Log("Is at destination");
            return;
        }
        var direction = destination - transform.position;
        transform.Translate(direction.normalized * Time.deltaTime * speed);
    }

    private bool isAtDestination() {
        return (transform.position - destination).magnitude <= detectionRadius;
    }
}
