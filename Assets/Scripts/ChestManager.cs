using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private Slot chestSlot;
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private int numberOfSlots;

    private List<Vector3> positions = new List<Vector3>();

    private void Start()
    {
        CreateSlots();
    }

    private void CreateSlots()
    {
        Vector3Int tilePosition = tilemap.cellBounds.min;

        for (int i = 0; i < numberOfSlots; i++)
        {
            GameObject slot = Instantiate(chestSlot.slot, tilemap.CellToWorld(tilePosition), Quaternion.identity);
            positions.Add(slot.transform.position);
            slot.transform.parent = tilemap.transform;

            tilePosition.x = tilePosition.x + 5;

            if (i % 4 == 3)
            {
                tilePosition.x = tilemap.cellBounds.min.x;
                tilePosition.y = tilePosition.y - 3;
            }
        }
    }

    public void SetSlotState(SlotType slotType, Slot slot)
    {
        slot.slotType = slotType;
    }

    public Vector3 GetPosition()
    {
        Vector3 possiblePosition = positions[0];
        return possiblePosition;
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
    public GameObject slot;
    public Vector3 position;
    public SlotType slotType;
}
