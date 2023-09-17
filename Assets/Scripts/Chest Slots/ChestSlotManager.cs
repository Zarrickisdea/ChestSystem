using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChestSlotManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int numberOfSlots;

    [SerializeField] private Slot chestSlot;

    private List<Slot> slots = new List<Slot>();

    private void Start()
    {
        CreateSlots();
    }

    private void CreateSlots()
    {
        Vector3Int tilePosition = tilemap.cellBounds.min;

        for (int i = 0; i < numberOfSlots; i++)
        {
            Slot slot = new Slot();
            GameObject emptySlot = Instantiate(chestSlot.slotObject, tilemap.GetCellCenterWorld(tilePosition), Quaternion.identity);
            slot.slotObject = emptySlot;
            slot.slotType = SlotType.Empty;
            emptySlot.transform.SetParent(tilemap.transform);
            slots.Add(slot);

            tilePosition.x = tilePosition.x + 5;

            if (i % 4 == 3)
            {
                tilePosition.x = tilemap.cellBounds.min.x;
                tilePosition.y = tilePosition.y - 3;
            }
        }
    }

    public void AddItem(GameObject item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.slotType == SlotType.Empty)
            {
                slot.slotType = SlotType.Filled;
                item.transform.position = slot.slotObject.transform.position;
                item.transform.SetParent(slot.slotObject.transform);
                break;
            }
        }
    }

    public void RemoveItem(GameObject item)
    {
        foreach (Slot slot in slots)
        {
            if (slot.slotType == SlotType.Filled && slot.slotObject.transform.childCount > 0)
            {
                if (slot.slotObject.transform.GetChild(0).gameObject == item)
                {
                    slot.slotType = SlotType.Empty;
                    item.transform.SetParent(null);
                    break;
                }
            }
        }
    }
}

public enum SlotType
{
    Empty,
    Filled
}

[Serializable]
public class Slot
{
    public GameObject slotObject;
    public SlotType slotType;
}
