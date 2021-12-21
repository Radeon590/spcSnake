using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move_NPC))]
public class Logic_NPC : MonoBehaviour
{
    [SerializeField] private Transform[] movementPoints;
    //
    private Move_NPC _moveNpc;
    //
    private int movementDirection = 0;
    //

    private void Awake()
    {
        _moveNpc = GetComponent<Move_NPC>();
        StandartMovement();
    }

    private void StandartMovement()
    {
        _moveNpc.StartMovement(movementPoints[movementDirection].position);
        if (movementDirection == movementPoints.Length - 1)
        {
            movementDirection = 0;
        }
        else
        {
            movementDirection++;
        }
    }

    public void PlayerDetectedMovement(Vector2 playerPos)
    {
        _moveNpc.ForceEndMovement();
        _moveNpc.StartMovement(playerPos);
    }
}
