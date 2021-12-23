using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverableEntity_UI : MonoBehaviour, IPointerEnterHandler
{
    [SerializeField] private MouseController mouseController;
    
    public void OnPointerEnter(PointerEventData eventData)
    {
        throw new NotImplementedException();
    }
}
