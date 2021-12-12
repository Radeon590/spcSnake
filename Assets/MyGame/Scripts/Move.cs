using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed;                     // �������� (������� ���������, ����� ����� ������, �������� �� ������� � ��)
    public Slider Stamina;                 // ��������� Slider
    [SerializeField]
    private int Diff;                       // ���������� �������� ������������
    private Vector3 V3;                     // ��� �����������
    private bool isMoving = false;          // ��� �������� �� ��������
    void Update()
    {
        if (Input.GetMouseButton(0))        // �������� �� ������� ����
        {
            TriggerPosition();
        }

        if (isMoving == true && Stamina.value > Stamina.minValue)
        {
            Moving();
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
        transform.rotation = Quaternion.LookRotation(Vector3.forward, V3);      // �������� �� ������� �������, ����� �����������
        transform.position = Vector3.MoveTowards(transform.position, V3, speed * Time.deltaTime);   // ������������ �������

        if (transform.position == V3)       // ���������� ������������, ��� ������ �� ������� �� ����
        {
            isMoving = false;
        }
    }
}
