using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Security.Cryptography;
using CoinPackage.Debugging;
using Garden;
using UnityEngine;

[RequireComponent(typeof(Draggable))]
public class Child : MonoBehaviour
{
    // Start is called before the first frame update
    
    // TODO: Require collider
    public int level;

    // private void OnCollisionEnter(Collision collision)
    // {
    //     // TODO: Make it safe
    //     Child colliderChild = collision.collider.GetComponent<Child>();
    //     if (colliderChild.level == level)
    //     {
    //         CreateNextLevelChild();
    //         
    //         colliderChild.Death();
    //         Death();
    //     }
    // }

    private void Death()
    {
        // TODO: suicide pls
    }

    public void OnDragStarted()
    {
        
    }

    public int GetLevel()
    {
        return level;
    }

    public void OnDragEnded()
    {
        var colliders = Physics2D.OverlapCircleAll(transform.position, 0.1f);
        foreach (var collider in colliders)
        {
            if (collider.gameObject == gameObject)
            {
                continue;
            }
            var child = collider.gameObject.GetComponent<Child>();
            if (child)
            {
                if (child.GetLevel() == level)
                {
                    ChildManager.Instance.CreateNewChildLevelHigher(level+1, child.transform.position);
                    Destroy(child.gameObject);
                    Destroy(gameObject);
                    return;
                }
            }
        }
    }
}
