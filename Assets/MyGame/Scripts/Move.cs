using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Move : MonoBehaviour
{
    public float speed;                     // Скорость (Оставил публичным, может будем менять, наступая на ловушки и тд)
    public Slider Stamina;                 // Инициация Slider
    [SerializeField]
    private int Diff;                       // Коэфициент снижения выносливости
    private Vector3 V3;                     // Для перемещения
    private bool isMoving = false;          // Для проверки на движение
    void Update()
    {
        if (Input.GetMouseButton(0))        // Проверка на нажатие мыши
        {
            TriggerPosition();
        }

        if (isMoving == true && Stamina.value > Stamina.minValue)
        {
            Moving();
        }
    }

    void TriggerPosition()                  // Определение направления
    {
        V3 = Camera.main.ScreenToWorldPoint(Input.mousePosition); // Не ебу как работает, можешь объяснить? Ибо тому челу было похуй. Как я понял, эта хуйня определяет, куда идти.
                                                                  // Я понял всё, кроме момента, почему всё идёт от камеры?
        V3.z = transform.position.z;

        isMoving = true;
    }

    void Moving()                           // Направление
    {
        Stamina.value = Stamina.value - Diff * Time.deltaTime;      // Снижение выносливости
        transform.rotation = Quaternion.LookRotation(Vector3.forward, V3);      // Отвечает за поворот объекта, может понадобится
        transform.position = Vector3.MoveTowards(transform.position, V3, speed * Time.deltaTime);   // Передвижение объекта

        if (transform.position == V3)       // Отключение передвижения, как только ГГ доходит до мыши
        {
            isMoving = false;
        }
    }
}
