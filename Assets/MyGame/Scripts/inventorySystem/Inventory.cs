using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class InventorySlot {
    public Item item;
    public int amount;

    public InventorySlot(Item itemm, int amount = 1) {
        this.item = item;
        this.amount = amount;
    }
}
public class Inventory : MonoBehaviour
{
    [SerializeField]
    private List<InventorySlot> items = new List<InventorySlot>();
    public void AddItem(Item item, int amount = 1) {
        foreach (InventorySlot slot in items) {
            if (slot.item.id == item.id) {
                slot.amount += amount;
                return;
            }
        }
        InventorySlot new_slot = new InventorySlot(item, amount);
        items.Add(new_slot);
    }
}
