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

    public int money = 0;

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

    public void AddMoney(int money)
    {
        this.money += money;
    }

    public bool RemoveMoney(int money)
    {
        if (money > this.money)
        {
            return false;
        }

        this.money -= money;
        return true;
    }
}
