using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StateMachine : MonoBehaviour
{
    public delegate void OnPlayerTurn();

    public OnPlayerTurn onPlayerTurn;
    //
    public delegate void OnEnemyTurn();

    public OnEnemyTurn onEnemyTurn;
    //
    
    public TurnStates CurrentState
    {
        set
        {
            switch (value)
            {
                case TurnStates.playerTurn:
                    onPlayerTurn.Invoke();
                    break;
                case TurnStates.enemiesTurn:
                    onEnemyTurn.Invoke();
                    break;
            }
            
            _currentState = value;
        }
    }

    private TurnStates _currentState;

    private void Awake()
    {
        CurrentState = TurnStates.playerTurn;
    }
}

public enum TurnStates
{
    playerTurn,
    enemiesTurn
}
