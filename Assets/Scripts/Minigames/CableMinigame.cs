using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CableMinigame : MonoBehaviour
{

    public int switchesNeeded = 5;

    public void HandleSwitch()
    {
        switchesNeeded--;
        if (switchesNeeded == 0)
        {
            // TODO: Daj znać ze zakonczona minigierka
            Destroy(gameObject);
        }
    }
}
