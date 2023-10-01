using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Player : MonoBehaviour {
    public static Player Instance = null;
    public MoveTo moveTo;
    public Animator animator;
    public NavMeshAgent agent;

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    void Start() {
        moveTo = GetComponent<MoveTo>();
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Update() {
        animator.SetFloat("Velocity", agent.velocity.magnitude);
    }
}
