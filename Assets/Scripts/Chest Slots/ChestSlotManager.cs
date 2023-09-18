using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChestSlotManager : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int numberOfSlots;

    [SerializeField] private Slot chestSlot;

    private Queue<Slot> slots = new Queue<Slot>();

    private void Awake()
    {
        CreateSlots();
    }

    public void CreateSlots()
    {
        Vector3Int tilePosition = tilemap.cellBounds.min;

        for (int i = 0; i < numberOfSlots; i++)
        {
            Slot slot = new Slot();
            GameObject emptySlot = Instantiate(chestSlot.slotObject, tilemap.GetCellCenterWorld(tilePosition), Quaternion.identity);
            slot.slotObject = emptySlot;
            slot.slotPosition = tilemap.GetCellCenterWorld(tilePosition);
            slot.slotType = SlotType.Empty;
            emptySlot.transform.SetParent(tilemap.transform);
            slots.Enqueue(slot);

            tilePosition.x = tilePosition.x + 5;

            if (i % 4 == 3)
            {
                tilePosition.x = tilemap.cellBounds.min.x;
                tilePosition.y = tilePosition.y - 2;
            }
        }
    }

    public Vector3 GetEmptyPosition()
    {
        if (slots.Count != 0)
        {
            Slot slot = slots.Dequeue();
            print(slot.slotType);
            slot.slotType = SlotType.Filled;
            return slot.slotPosition;
        }
        else
        {
            return Vector3.zero;
        }
    }

    public int GetNumberOfSlots()
    {
        return numberOfSlots;
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
    public Vector3 slotPosition;
    public SlotType slotType;
}
