using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoverableEntity : MonoBehaviour
{
    public List<HoverableEntityType> HoverableEntityTypes;
}

public enum HoverableEntityType
{
    attack,
    basic,
    dialog,
    hand,
    point,
    transform,
    none
}
