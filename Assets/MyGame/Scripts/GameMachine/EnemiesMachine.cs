using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMachine : MonoBehaviour
{
    [SerializeField] private StateMachine stateMachine;
    [SerializeField] private float enemiesActivityDistance = 15;
    //
    public List<Logic_NPC> LogicNpc = new List<Logic_NPC>();
    //
    private int _moovingEnemies = 0;
    public int MovedEnemies = 0;
    bool needCheck = false;
    

    private void Start()
    {
        stateMachine = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateMachine>();
        stateMachine.onEnemyTurn += OnEnemiesTurn;
    }

    public void OnEnemiesTurn()
    {
        foreach (var VARIABLE in LogicNpc)
        {
            VARIABLE.EnemiesMachine = this;
            bool needMakeTurn = VARIABLE.MakeTurn(enemiesActivityDistance);
            if (needMakeTurn)
                _moovingEnemies++;
        }
        //
        needCheck = true;
    }

    private void FixedUpdate()
    {
        if (needCheck)
        {
            if (MovedEnemies == _moovingEnemies)
            {
                if (stateMachine.CurrentState != TurnStates.death)
                {
                    _moovingEnemies = 0;
                    MovedEnemies = 0;
                    needCheck = false;
                    //
                    stateMachine.CurrentState = TurnStates.playerTurn;
                }
            }
        }
    }
}
