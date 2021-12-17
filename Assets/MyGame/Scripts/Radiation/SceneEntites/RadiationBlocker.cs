using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationBlocker : MonoBehaviour
{
    [SerializeField] private float radiationBlockMultiplyer = 2;

    public float BlockRadiation(float strength)
    {
        return  strength / radiationBlockMultiplyer;
    }
}
