using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class HoverableEntity_UI : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private MouseController mouseController;

    private void Start()
    {
        mouseController = GameObject.Find("PlayerControllers").GetComponent<MouseController>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("enter");
        mouseController.FocusedOnUI = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        mouseController.FocusedOnUI = false;
    }
}
