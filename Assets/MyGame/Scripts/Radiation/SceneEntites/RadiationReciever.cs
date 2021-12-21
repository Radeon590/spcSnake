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
    //
    private bool isRadiationSource = false;
    private float radiationSourceTime = 3;

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
        //radiation itself timer
        if (isRadiationSource)
        {
            if (radiationSourceTime < 3)
            {
                radiationSourceTime += Time.deltaTime;
            }
            if(_radiationValue == 0)
            {
                GameObject radSource = transform.GetChild(0).gameObject;
                RadiationSource source;
                if (radSource.TryGetComponent(out source))
                {
                    Debug.Log("destroy");
                    isRadiationSource = false;
                    Destroy(radSource);
                }            
            }
        }
        //rad bar value update
        /*if (radiationBar.value < _radiationValue)
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
        }*/
    }

    private void BecomeSource()
    {
        if (!gameObject.isStatic)
        {
            if (!isRadiationSource)
            {
                GameObject newSource = Instantiate(radiationSource_pref);
                newSource.layer = 6;
                newSource.transform.parent = this.transform;
                isRadiationSource = true;
                radiationSourceTime = 0;
            }
        }
    }
}
