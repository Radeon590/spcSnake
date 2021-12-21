using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject WaitingScreen;
    //
    [SerializeField] private Move playerMove;
    //
    private StateMachine stateMachine;

    private void Start()
    {
        Debug.Log(GameObject.FindGameObjectWithTag("GameController").name);
        stateMachine = GameObject.FindGameObjectWithTag("GameController").GetComponent<StateMachine>();
        stateMachine.onPlayerTurn += StartPlayerTurn;
        //
        playerMove.PlayerController = this;
        //
        stateMachine.CurrentState = TurnStates.playerTurn;
    }

    public void StartPlayerTurn()
    {
        WaitingScreen.SetActive(false);
        playerMove.enabled = true;
    }

    public void EnemyTurn()
    {
        WaitingScreen.SetActive(true);
        playerMove.enabled = false;
        //
        stateMachine.CurrentState = TurnStates.enemiesTurn;
    }
}
