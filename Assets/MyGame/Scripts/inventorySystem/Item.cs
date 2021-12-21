using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum InventoryElement { 
    box,
    smalTree
}
public class Item : MonoBehaviour
{
    public InventoryElement Element;
}
