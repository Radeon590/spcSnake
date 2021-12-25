using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MouseController : MonoBehaviour
{
    [HideInInspector]
    public bool FocusedOnUI
    {
        set
        {
            if (value == true)
            {
                lastCursor = CurrentCursor;
                CurrentCursor = HoverableEntityType.basic;
            }
            else
            {
                CurrentCursor = lastCursor;
            }
            
            _focusedOnUI = value;
        }

        get
        {
            return _focusedOnUI;
        }
    }

    private bool _focusedOnUI = false;

    private HoverableEntityType lastCursor;
    //
    [SerializeField] private Sprite[] cursorSprites; //назначать сторого в том порядке как спрайты идут в enum HoverableTypes
    private Vector2 _mousePos;
    
    [HideInInspector] public HoverableEntityType CurrentCursor
    {
        set
        {
            switch (value)
            {
                case HoverableEntityType.attack:
                    Cursor.SetCursor(cursorSprites[0].texture, Vector2.zero, CursorMode.Auto);
                    break;
                case HoverableEntityType.basic:
                    Cursor.SetCursor(cursorSprites[1].texture, Vector2.zero, CursorMode.Auto);
                    break;
                case HoverableEntityType.dialog:
                    Cursor.SetCursor(cursorSprites[2].texture, Vector2.zero, CursorMode.Auto);
                    break;
                case HoverableEntityType.hand:
                    Cursor.SetCursor(cursorSprites[3].texture, Vector2.zero, CursorMode.Auto);
                    break;
                case HoverableEntityType.point:
                    Cursor.SetCursor(cursorSprites[4].texture, Vector2.zero, CursorMode.Auto);
                    break;
                case HoverableEntityType.transform:
                    Cursor.SetCursor(cursorSprites[5].texture, Vector2.zero, CursorMode.Auto);
                    break;
                case HoverableEntityType.none:
                    Cursor.SetCursor(cursorSprites[6].texture, Vector2.zero, CursorMode.Auto);
                    break;
            }

            _currentCursor = value;
        }

        get
        {
            return _currentCursor;
        }
    }

    private HoverableEntityType _currentCursor = HoverableEntityType.basic;

    public HoverableEntityType currentMouseMode = HoverableEntityType.basic;
    
    private void Start()
    {
        _mousePos = Input.mousePosition;
    }

    private void FixedUpdate()
    {
        
        
        #region Проверкана на изменение курсора

        if (!_focusedOnUI)
        {
            if (IsMouseMoved())
            {
                HoverableEntity entity;
                GameObject objectUnderMouse = GetObjectUnderMouse();
                if (objectUnderMouse != null)
                {
                    objectUnderMouse.TryGetComponent(out entity);
                    if (entity != null)
                    {
                        if (entity.HoverableEntityTypes.Contains(currentMouseMode))
                        {
                            CurrentCursor = currentMouseMode;
                        }
                        else
                        {
                            CurrentCursor = HoverableEntityType.basic;
                        }
                    }
                }
                else
                {
                    CurrentCursor = HoverableEntityType.basic;
                }
            }
        }

        #endregion
    }

    public bool IsMouseMoved()
    {
        float mousePos_delta = Vector2.Distance(_mousePos, Input.mousePosition);
        if (mousePos_delta > 5)
        {
            return true;
        }

        return false;
    }

    public GameObject GetObjectUnderMouse()
    {
        GameObject result = null;
        //
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 raycastFinalPos = new Vector3(mousePos.x, mousePos.y, mousePos.z + 30);
        int layerMask = 1 << 6;
        /*RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos, raycastFinalPos, 30, ~layerMask);
        if (hits.Length > 0)
        {
            if (hits[hits.Length - 1].collider != null)
            {
                result = hits[hits.Length - 1].collider.gameObject;
            }
        }*/
        RaycastHit2D hits = Physics2D.Raycast(mousePos, raycastFinalPos, 30, ~layerMask);
        if (hits.collider != null)
            {
                result = hits.collider.gameObject;
            }
        //
        return result;
    }
    //
    /*private bool _clicked = false;

    public bool Clicked
    {
        get
        {
            return _clicked;
        }
    }

    private void Update()
    {
        #region Проверка на клик

        if (Input.GetMouseButtonDown(0))
        {
            _clicked = true;
        }

        #endregion
    }*/
}
