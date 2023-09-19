using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ChestSlotManager : GenericSingleton<ChestSlotManager>
{
    [SerializeField] private LayoutGroup layoutGroup;
    [SerializeField] private int numberOfSlots;

    [SerializeField] private Slot chestSlot;

    private Queue<Slot> slots = new Queue<Slot>();

    private void Start()
    {
        CreateSlots();
    }

    public void CreateSlots()
    {
        for (int i = 0; i < numberOfSlots; i++)
        {
            Slot slot = new Slot();
            slot.slotObject = Instantiate(chestSlot.slotObject, layoutGroup.transform);
            slot.slotPosition = slot.slotObject.transform.position;
            slot.unlockButton = slot.slotObject.GetComponentInChildren<Button>();
            UIManager.Instance.ChestUnlockButtonControl(slot.unlockButton);
            slot.slotType = SlotType.Empty;
            slots.Enqueue(slot);
        }
    }

    public Slot GetEmptySlot()
    {
        if (slots.Count > 0)
        {
            Slot slot = slots.Dequeue();
            UIManager.Instance.ChestUnlockButtonControl(slot.unlockButton);
            slot.slotType = SlotType.Filled;
            return slot;
        }
        else
        {
            return null;
        }
    }

    public int GetNumberOfEmptySlots()
    {
        return slots.Count;
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
    public Button unlockButton;
    public Vector3 slotPosition;
    public SlotType slotType;
}
