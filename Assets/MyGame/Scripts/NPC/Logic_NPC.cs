using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Move_NPC), typeof(PlayerDetector))]
public class Logic_NPC : MonoBehaviour
{
    public EnemiesMachine EnemiesMachine;
    //
    [SerializeField] private Transform[] movementPoints;
    //
    private Move_NPC _moveNpc;
    //
    public int MovementDirection
    {
        set
        {
            if (_movementDirection < movementPoints.Length - 1)
            {
                _movementDirection = value;
            }
            else
            {
                _movementDirection = 0;
            }
        }
        get
        {
            return _movementDirection;
        }
    }
    
    private int _movementDirection = 0;

    private void Awake()
    {
        EnemiesMachine = GameObject.FindGameObjectWithTag("GameController").GetComponent<EnemiesMachine>(); 
        EnemiesMachine.LogicNpc.Add(this);
        //
        _moveNpc = GetComponent<Move_NPC>();
    }

    public bool MakeTurn(float enemiesActivityDistance)
    {
        PlayerDetector playerDetector = GetComponent<PlayerDetector>();
        if (playerDetector.CheckDistnace(enemiesActivityDistance))
        {
            _moveNpc.staminaValue = 1;
            _moveNpc.onStaminaEnd += EndTurn;
            if (GetComponent<PlayerDetector>().IsPlayerDetected())
            {
                PlayerDetectedMovement(GameObject.FindGameObjectWithTag("Player").transform.position);
            }
            else
            {
                StandartMovement();
            }

            return true;
        }

        return false;
    }

    private void StandartMovement()
    {
        _moveNpc.onNPCArrived = null;
        _moveNpc.onNPCArrived += OnEnemyArrived_toPoint;
        _moveNpc.StartMovement(movementPoints[MovementDirection].position);
    }

    public void PlayerDetectedMovement(Vector2 playerPos)
    {
        _moveNpc.ForceEndMovement();
        _moveNpc.onNPCArrived = null;
        _moveNpc.onNPCArrived += OnEnemyArrived_toPlayer;
        _moveNpc.StartMovement(playerPos);
    }
    //
    public void OnEnemyArrived_toPoint()
    {
        MovementDirection++;
        StandartMovement();
    }

    public void OnEnemyArrived_toPlayer()
    {
        Debug.Log("arrivedToPLayer");
        HP hp = GameObject.Find("PlayerControllers").GetComponent<HP>();
        hp.HP_Level = 0.5f;
        EndTurn();
    }
    //
    public void EndTurn()
    {
        EnemiesMachine.MovedEnemies++;
    }
}
