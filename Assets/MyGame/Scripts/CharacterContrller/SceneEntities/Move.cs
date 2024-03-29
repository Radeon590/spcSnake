using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    [HideInInspector] public PlayerController PlayerController;
    [SerializeField] private MouseController mouseController;
    //
    public float speed;                     // �������� (������� ���������, ����� ����� ������, �������� �� ������� � ��)
    public Slider Stamina;                 // ��������� Slider
    [SerializeField]
    private int Diff;                       // ���������� �������� ������������
    private Vector3 V3;                     // ��� �����������
    private bool isMoving = false;          // ��� �������� �� ��������
    
    private void OnEnable()
    {
        Stamina.value = Stamina.maxValue;
        isMoving = false;
    }
    
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && mouseController.CurrentCursor == HoverableEntityType.point)        // �������� �� ������� ����
        {
            TriggerPosition();
        }

        if (isMoving == true && Stamina.value > Stamina.minValue)
        {
            Moving();
        }

        if (Stamina.value <= Stamina.minValue)
        {
            PlayerController.EnemyTurn();
        }
    }

    void TriggerPosition()                  // ����������� �����������
    {
        V3 = Camera.main.ScreenToWorldPoint(Input.mousePosition); // �� ��� ��� ��������, ������ ���������? ��� ���� ���� ���� �����. ��� � �����, ��� ����� ����������, ���� ����.
                                                                  // � ����� ��, ����� �������, ������ �� ��� �� ������?
        V3.z = transform.position.z;

        isMoving = true;
    }

    void Moving()                           // �����������
    {
        Stamina.value = Stamina.value - Diff * Time.deltaTime;      // �������� ������������
        //transform.rotation = Quaternion.LookRotation(Vector3.forward, V3);      // �������� �� ������� �������, ����� �����������
        transform.position = Vector3.MoveTowards(transform.position, V3, speed * Time.deltaTime);   // ������������ �������

        if (transform.position == V3)       // ���������� ������������, ��� ������ �� ������� �� ����
        {
            isMoving = false;
        }
    }

    
}
