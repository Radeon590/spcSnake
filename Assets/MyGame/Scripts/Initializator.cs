using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private Transform mainHero;
    [SerializeField] private StateMachine statwMachine;
    
    public void StartGame()
    {
        //TODO: добавить функцию генерации
        
        //TODO:нужна позиуия для спавна игрока
        //mainHero.position = ;
        statwMachine.CurrentState = TurnStates.playerTurn;
    }
}
