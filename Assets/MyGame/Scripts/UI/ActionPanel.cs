using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionPanel : MonoBehaviour
{
    [SerializeField] private MouseController mouseController;
    
    #region Buttons

    public void Move()
    {
        mouseController.currentMouseMode = HoverableEntityType.point;
    }
    
    public void Hand()
    {
        mouseController.currentMouseMode = HoverableEntityType.hand;
    }
    
    public void Attack()
    {
        mouseController.currentMouseMode = HoverableEntityType.attack;
    }
    
    public void Transform()
    {
        mouseController.currentMouseMode = HoverableEntityType.transform;
    }

    #endregion
}
