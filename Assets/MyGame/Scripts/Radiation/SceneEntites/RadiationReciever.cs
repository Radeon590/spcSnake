using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadiationReciever : MonoBehaviour
{
    #region radiation

    [SerializeField] private GameObject radiationSource_pref;
    [SerializeField] private Slider radiationBar;
    [Space] 
    public float radHealingSpeed = 20;

    public float RadiationValue
    {
        set
        {
            _radiationValue = value;
            if (_radiationValue > 100)
            {
                _radiationValue = 100;
            }
            //
            _radiationBarAdditionalMultiplier = (5 * value) / 10;
            //
            BecomeSource();
        }
        get
        {
            return _radiationValue;
        }
    }

    private float _radiationValue = 0;
    private float _radiationBarAdditionalMultiplier = 0;

    #endregion

    private RadiationSource[] sources;
    //
    private float timer = 0;

    private void Start()
    {
        sources = FindObjectsOfType<RadiationSource>();
    }

    private void Update()
    {
        //collision check
        timer += Time.deltaTime;
        List<bool> insideSources = new List<bool>();
        if (timer > 0.2f)
        {
            foreach (var VARIABLE in sources)
            {
                insideSources.Add(VARIABLE.CheckRecieversInside(this));
            }
            //healing
            if (!insideSources.Contains(true))
            {
                _radiationValue -= radHealingSpeed;
            }
            //
            timer = 0;
        }
        //rad bar value update
        if (radiationBar.value < _radiationValue)
        {
            radiationBar.value += Time.deltaTime * _radiationBarAdditionalMultiplier;
        }
        else if(radiationBar.value > _radiationValue)
        {
            radiationBar.value -= Time.deltaTime * (5 * radHealingSpeed / 10);
        }
        else
        {
            radiationBar.value = _radiationValue;
        }
    }

    private void BecomeSource()
    {
        if (!gameObject.isStatic)
        {
            RadiationSource source;
            if (transform.childCount > 0)
            {
                if (!transform.GetChild(0).gameObject.TryGetComponent(out source))
                {
                    source = this.gameObject.AddComponent<RadiationSource>();
                }
            }
        }
    }
}
