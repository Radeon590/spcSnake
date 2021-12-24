using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HP : MonoBehaviour
{
    [SerializeField] private Slider hpBar;
    [SerializeField] private StateMachine stateMachine;
    
    public float HP_Level
    {
        set
        {
            _hp_level -= value;
            if (_hp_level <= 0)
            {
                hpBar.value = 0f;
                stateMachine.CurrentState = TurnStates.death;
            }
            else
            {
                hpBar.value = _hp_level;
            }
        }
        get
        {
            return _hp_level;
        }
    }

    private float _hp_level = 1;
}
