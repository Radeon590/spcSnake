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
    public delegate void OnDeath();

    public OnDeath onDeath;
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
                case TurnStates.death:
                    onDeath.Invoke();
                    break;
            }
            
            _currentState = value;
        }

        get
        {
            return _currentState;
        }
    }

    private TurnStates _currentState;
}

public enum TurnStates
{
    playerTurn,
    enemiesTurn,
    death
}
