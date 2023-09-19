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
            Slot slot = CreateSlot();
            slots.Enqueue(slot);
        }
    }

    private Slot CreateSlot()
    {
        Slot slot = new Slot();
        slot.slotObject = Instantiate(chestSlot.slotObject, layoutGroup.transform);
        slot.slotPosition = slot.slotObject.transform.position;
        slot.unlockButton = slot.slotObject.GetComponentInChildren<Button>();
        slot.timer = slot.slotObject.GetComponentsInChildren<TextMeshProUGUI>()[1];
        slot.rewardsPanel = slot.slotObject.GetComponentsInChildren<RectTransform>()[4].gameObject;
        UIManager.Instance.SetObjectState(slot.rewardsPanel, false);
        UIManager.Instance.SetObjectState(slot.timer.gameObject, false);
        UIManager.Instance.SetObjectState(slot.unlockButton.gameObject, false);
        slot.slotType = SlotType.Empty;
        return slot;
    }

    public Slot GetEmptySlot()
    {
        if (slots.Count > 0)
        {
            Slot slot = slots.Dequeue();
            UIManager.Instance.SetObjectState(slot.unlockButton.gameObject, true);
            slot.slotType = SlotType.Filled;
            return slot;
        }
        else
        {
            return CreateSlot();
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

    public void AddToSlotQueue(Slot slot)
    {
        UIManager.Instance.SetObjectState(slot.unlockButton.gameObject, false);
        UIManager.Instance.SetObjectState(slot.timer.gameObject, false);
        slot.slotType = SlotType.Empty;
        slots.Enqueue(slot);
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
    public GameObject rewardsPanel;
    public Button unlockButton;
    public TextMeshProUGUI timer;
    public Vector3 slotPosition;
    public SlotType slotType;
}
