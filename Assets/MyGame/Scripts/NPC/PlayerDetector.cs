using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDetector : MonoBehaviour
{
    [SerializeField] private float detectDistance = 4;
    //
    private GameObject player;
    //
    private bool seen = false;
    private float seenTimer = 0;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    public bool IsPlayerDetected()
    {
        if (CheckDistnace(detectDistance))
        {
            return CheckIfSee();
        }

        return false;
    }

    public bool CheckDistnace(float distance)
    {
        if (Vector2.Distance(player.transform.position, transform.position) < distance)
        {
            return true;
        }

        return false;
    }
    
    private bool CheckIfSee()
    {
        int layerMask = 1 << 6;
        
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float distance = Vector2.Distance(transform.position, player.transform.position) + 1;
        RaycastHit2D[] hits2D = Physics2D.RaycastAll(transform.position, direction, distance, ~layerMask);
        //
        if (hits2D != null)
        {
            foreach (var VARIABLE in hits2D)
            {
                if (VARIABLE.collider.gameObject.tag == "Player")
                {
                    Debug.Log("true");
                    return true;
                }
            }
        }
        //
        return false;
    }
}
