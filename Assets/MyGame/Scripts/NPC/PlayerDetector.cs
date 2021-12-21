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

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Vector2.Distance(player.transform.position, transform.position) < detectDistance)
        {
            CheckIfSee();
        }
    }

    private void Update()
    {
        if (seen)
        {
            seenTimer += Time.deltaTime;
        }
    }

    private void CheckIfSee()
    {
        int layerMask = 1 << 6;

        RaycastHit2D hits2D = Physics2D.Raycast(transform.position, player.transform.position, detectDistance, ~layerMask);
        //
        if (hits2D != null)
        {
            if (hits2D.collider.gameObject.tag == "Player")
            {
                seen = true;
            }
        }
    }
}
