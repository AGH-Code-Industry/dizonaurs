using System.Collections;
using System.Collections.Generic;
using Minigames;
using UnityEngine;

public class CableMinigame : MonoBehaviour
{

    public int switchesNeeded = 5;
    public Cables controller;

    public void HandleSwitch()
    {
        switchesNeeded--;
        if (switchesNeeded == 0)
        {
            controller.Repair();
            Destroy(gameObject);
        }
    }
}
