using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private float width;
    [SerializeField] private float height;

    public float GetWidth()
    {
        return width;
    }

    public float GetHeight()
    {
        return height;
    }
}
