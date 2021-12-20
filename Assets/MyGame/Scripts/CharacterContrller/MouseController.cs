using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    public GameObject ClickObject()
    {
        GameObject result = null;
        //
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 raycastFinalPos = new Vector3(mousePos.x, mousePos.y, mousePos.z + 30);
        int layerMask = 1 << 6;
        RaycastHit2D hit2d = Physics2D.Raycast(mousePos, raycastFinalPos, 30, ~layerMask);
        result = hit2d.collider.gameObject;
        //
        return result;
    }

    public void ClickPos()
    {
        
    }
}
