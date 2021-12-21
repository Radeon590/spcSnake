using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventorySlot {
    public Item item;

    public InventorySlot(GameObject itemm) {
        this.item = item;
    }
}
public class Inventory : MonoBehaviour
{
    private InventorySlot slot = new InventorySlot(null);
    public void AddItem(Item item) {
        slot.item = item;
    } 
}
