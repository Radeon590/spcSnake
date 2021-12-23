using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using Random = System.Random;

public class MapGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private List<Room> rooms;
    [SerializeField] private Room firstRoom;
    [SerializeField] private Room defaultRoom;

    [SerializeField] private Room[,] map = new Room[10,10];
    private static Random rnd = new Random();
    private int _cursorPoint = rnd.Next(1, 9) * 10 + rnd.Next(1, 9);
    private int _roomsCount = rnd.Next(2) + 4;

    private bool OnlyOneNeighboor(int cursor)
    {
        int neighboorCount = 0;
        if (cursor % 10 > 0)
        {
            if (map[cursor / 10, cursor % 10 - 1] != defaultRoom)
                ++neighboorCount;
        }

        if (cursor % 10 < 9)
        {
            if (map[cursor / 10, cursor % 10 + 1] != defaultRoom)
                ++neighboorCount;
        }
        
        if (cursor / 10 < 9)
        {
            if (map[cursor / 10 + 1, cursor % 10] != defaultRoom)
                ++neighboorCount;
        }
        
        if (cursor / 10 > 0)
        {
            if (map[cursor / 10 - 1, cursor % 10] != defaultRoom)
                ++neighboorCount;
        }

        if (neighboorCount > 1)
            return false;
        return true;
    }

    void SpawnMap()
    {
        for (var i = 0; i < 10; ++i)
        {
            for (var j = 0; j < 10; ++j)
            {
                var obj = Instantiate(map[i, j]);
                obj.transform.position = new Vector2(1f * obj.GetComponent<Room>().GetWidth(),1f * obj.GetComponent<Room>().GetHeight());
            }
        }
    }
    void Start()
    {
        for (int i = 0; i < 10; ++i)
        {
            for (int j = 0; j < 10; ++j)
            {
                map[i, j] = defaultRoom;
            }
        }
        map[_cursorPoint/10, _cursorPoint%10] = firstRoom;
        int n = 0;
        while (_roomsCount > 0)
        {
            n = 0;
            for (int i = 0; i < 4; ++i)
            {
                if (++n > 2)
                {
                    break;
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
