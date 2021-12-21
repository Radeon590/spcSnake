using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move_NPC : MonoBehaviour
{
    [SerializeField] private float speed = 0.9f;
    //
    private Vector2 CurrentTarget = Vector2.zero;

    public delegate void Arrived();

    public Arrived onNPCArrived;
    //
    private Vector2 lastPos;
    private bool move = false;
    private float timer = 0;
    
    private void Update()
    {
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
