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
            if (_hp_level - value <= 0)
            {
                hpBar.value = 0;
                stateMachine.CurrentState = TurnStates.death;
            }
            else
            {
                _hp_level -= value;
                hpBar.value = _hp_level;
            }
        }
        get
        {
            return _hp_level;
        }
    }

    private float _hp_level = 0;
}
