using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Move_NPC : MonoBehaviour
{
    [SerializeField] private float speed = 0.6f;
    //
    private Vector2 CurrentTarget = Vector2.zero;

    public delegate void Arrived();

    public Arrived onNPCArrived;

    public Arrived onStaminaEnd;
    //
    private Vector2 lastPos;
    private bool move = false;
    private float timer = 0;
    //
    public float staminaValue = 1;
    
    private void Update()
    {
        if (move)
        {
            if (staminaValue > 0)
            {
                Move();
            }
            else
            {
                move = false;
                onStaminaEnd.Invoke();
            }
        }
    }

    private void Move()
    {
        staminaValue -= Time.deltaTime * 0.4f;
        timer += Time.deltaTime * speed;
        transform.position = Vector2.Lerp(lastPos, CurrentTarget, timer);
        if (timer >= 1)
        {
            move = false;
            onNPCArrived.Invoke();
        }
    }

    public void StartMovement(Vector2 vectorToMove)
    {
        CurrentTarget = vectorToMove;
        lastPos = transform.position;
        timer = 0;
        move = true;
    }

    public void ForceEndMovement()
    {
        move = false;
    }
}
