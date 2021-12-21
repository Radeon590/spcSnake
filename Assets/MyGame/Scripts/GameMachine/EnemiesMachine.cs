using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesMachine : MonoBehaviour
{
    [SerializeField] private StateMachine stateMachine;
    //
    public List<Logic_NPC> LogicNpc = new List<Logic_NPC>();

    private void Start()
    {
        stateMachine = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateMachine>();
        stateMachine.onEnemyTurn += OnEnemiesTurn;
    }

    public void OnEnemiesTurn()
    {
        foreach (var VARIABLE in LogicNpc)
        {
            VARIABLE.MakeTurn();
        }
    }
}
