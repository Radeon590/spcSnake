using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class RadiationCommon : MonoBehaviour
{
    public void CheckBlockers(Vector2 sourcePos, RadiationReciever reciever, float strength)
    {
        int layerMask = 1 << 6;
        float distance = Vector2.Distance(sourcePos, reciever.transform.position) + 1;

        RaycastHit2D[] hits2D = Physics2D.RaycastAll(sourcePos, reciever.transform.position, distance, ~layerMask);
        //
        if (hits2D != null)
        {
            foreach (var VARIABLE in hits2D)
            {
                RadiationBlocker radBlocker;
                RadiationReciever radReciever;
                if (VARIABLE.collider.gameObject.TryGetComponent(out radBlocker))
                {
                    strength = radBlocker.BlockRadiation(strength);
                }
                else if (VARIABLE.collider.gameObject.TryGetComponent(out radReciever))
                {
                    Debug.Log("rad");
                    reciever.RadiationValue += strength;
                }
            }
        }
    }
}
