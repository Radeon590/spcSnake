using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initializator : MonoBehaviour
{
    [SerializeField] private MapGenerator mapGenerator;
    [SerializeField] private Transform mainHero;
    [SerializeField] private StateMachine statwMachine;

    private void Start()
    {
        StartGame();
    }

    public void StartGame()
    {
        //TODO: добавить функцию генерации
        mapGenerator.GenerateRectMap();
        //TODO:нужна позиуия для спавна игрока
        mainHero.position = new Vector2(0.28f, 1.39f);
        mainHero.GetComponent<SkinRandomiser>().SetRandomSkin();
        //statwMachine.CurrentState = TurnStates.playerTurn;
    }
}
