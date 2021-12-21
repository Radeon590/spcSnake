using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RadiationSource : MonoBehaviour
{
    [SerializeField] private float influenceDistance = 10;
    [SerializeField] private float influenceStrength_max = 10;

    private Collider2D colider;
    private RadiationCommon _radiationCommon;

    private void Start()
    {
        colider = GetComponent<Collider2D>();
        _radiationCommon = gameObject.AddComponent<RadiationCommon>();
        //
        Vector3 scaleVector = new Vector3(influenceDistance, influenceDistance, 1);
        transform.localScale = scaleVector;
        //
        float particlesLifeTime = (0.9f * influenceDistance) / 6;
        ParticleSystem particleSystem = this.GetComponent<ParticleSystem>();
        ParticleSystem.MainModule mainModule = particleSystem.main;
        mainModule.startLifetime = particlesLifeTime;
        particleSystem.Play();
    }

    public bool CheckRecieversInside(RadiationReciever reciever)
    {
        if (colider.bounds.Contains(reciever.transform.position))
        {
            RecieverInside(reciever);
            return true;
        }

        return false;
    }

    private void RecieverInside(RadiationReciever reciever)
    {
        float strength = CalculateStrength(reciever.transform.position);
        _radiationCommon.CheckBlockers(transform.position, reciever, strength);
    }

    private float CalculateStrength(Vector2 recieverPos)
    {
        float distance = Vector2.Distance(transform.position, recieverPos);
        float percentsByDistance = distance / influenceDistance;
        float influenceValue = influenceStrength_max / percentsByDistance;

        return influenceValue;
    }
}
