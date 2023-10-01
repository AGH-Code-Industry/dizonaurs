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
    public GameObject cloud;
    public SpriteRenderer sprite;
    public float cloudDisplayTime;

    public int money = 0;
    private float timer;

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
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update() {
        animator.SetFloat("Velocity", agent.velocity.magnitude);
        SetDirection();
        if (cloud.activeSelf && Time.time - timer >= cloudDisplayTime) {
            cloud.SetActive(false);
        }
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

    public void DisplayCloud() {
        cloud.SetActive(true);
        timer = Time.time;
    }

    private void SetDirection() {
        if (agent.velocity.x < 0) {
            sprite.flipX = true;
        } else {
            sprite.flipX = false;
        }

    }
}
