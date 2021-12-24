using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List< GameObject> rooms;
    [SerializeField] private GameObject firstRoom;
    [SerializeField] private  GameObject defaultRoom;

    [SerializeField] private GameObject[,] map = new GameObject[4,4];
    private int xsize = 3;
    private int ysize = 3;
    private static Random rnd = new Random();
    private int _cursorPoint = rnd.Next(1, 9) * 10 + rnd.Next(1, 9);
    private int _roomsCount = rnd.Next(2) + 4;

    private bool OnlyOneNeighbor(int cursor)
    {
        var neighborCount = 0;
        if (cursor % 10 > 0)
        {
            if (map[cursor / 10, cursor % 10 - 1] != defaultRoom)
                ++neighborCount;
        }

        if (cursor % 10 < 9)
        {
            if (map[cursor / 10, cursor % 10 + 1] != defaultRoom)
                ++neighborCount;
        }
        
        if (cursor / 10 < 9)
        {
            if (map[cursor / 10 + 1, cursor % 10] != defaultRoom)
                ++neighborCount;
        }
        
        if (cursor / 10 > 0)
        {
            if (map[cursor / 10 - 1, cursor % 10] != defaultRoom)
                ++neighborCount;
        }

        if (neighborCount > 1)
            return false;
        return true;
    }

    void SpawnMap()
    {
        for (var i = 0; i < xsize; ++i)
        {
            for (var j = 0; j < ysize; ++j)
            {
                var obj = Instantiate(map[i, j]);
                obj.transform.position = new Vector2(i * obj.GetComponent<Room>().GetWidth(),j * obj.GetComponent<Room>().GetHeight());
            }
        }
    }

    public void GenerateMap()
    {
        Debug.Log("1");
        for (var i = 0; i < 10; ++i)
        {
            for (var j = 0; j < 10; ++j)
            {
                Debug.Log($"i:{i} j:{j}");
                map[i, j] = defaultRoom;
            }
        }
        map[_cursorPoint/10, _cursorPoint%10] = firstRoom;
        var n = 0;
        while (_roomsCount > 0)
        {
            for (var i = 0; i < 4; ++i)
            {
                Debug.Log($"i:{_roomsCount} ");
                if (++n%3==0)
                {
                    continue;
                }
                
                if (_cursorPoint / 10 < 9 && i == 0)
                {
                    _cursorPoint += 10;
                }
                else if (_cursorPoint / 10 > 0 && i == 1)
                {
                    _cursorPoint -= 10;
                }
                else if (_cursorPoint % 10 < 9 && i == 2)
                {
                    _cursorPoint += 1;
                }
                else if (_cursorPoint % 10 > 0 && i == 3)
                {
                    _cursorPoint -= 1;
                }

                if (map[_cursorPoint / 10, _cursorPoint % 10] != defaultRoom) continue;
                --_roomsCount;
                var randElement = rooms[rnd.Next(rooms.Count)];
                map[_cursorPoint / 10, _cursorPoint % 10] = randElement;
                rooms.Remove(randElement);

            }
        }

        SpawnMap();
    }
    float timer = 3f;
    private bool f = true;
    void GenerateRectMap()
    {
        for (var i = 0; i < xsize; ++i)
        {
            for (var j = 0; j < ysize; ++j)
            {
                var randElement = rooms[rnd.Next(rooms.Count)];
                map[i, j] = randElement;
                //rooms.Remove(randElement);//если сделать комнаты больше 10, то раскоментить надо эту строку
            }
        }

        SpawnMap();
    }


    void Start()
    {
        GenerateRectMap();
    }
}
