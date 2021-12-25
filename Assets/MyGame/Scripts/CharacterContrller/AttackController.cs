using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] private MouseController mouseController;

    private bool needCheck = true;
    
    private void Update()
    {
        if (needCheck)
        {
            if (mouseController.CurrentCursor == HoverableEntityType.attack)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    GameObject obj = mouseController.GetObjectUnderMouse();
                    if (obj.tag == "Enemy")
                    {
                        Destroy(obj);
                    }
                }
            }
        }
        
        
    }
}
