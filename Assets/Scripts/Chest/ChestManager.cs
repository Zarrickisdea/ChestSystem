using UnityEngine;

public class ChestManager : GenericSingleton<ChestManager>
{
    [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;
    private int activeChestCount = 0;

    public void CreateChest()
    {
        if (activeChestCount >= ChestSlotManager.Instance.GetNumberOfSlots())
        {
            return;
        }
        Slot slot = ChestSlotManager.Instance?.GetEmptySlot();
        if (slot != null)
        {
            Transform slotTransform = slot.slotObject.transform;
            ChestScriptableObject chestScriptableObject = chestScriptableObjectList.GetChest();
            ChestModel chestModel = new ChestModel(chestScriptableObject);
            ChestController chestController = new ChestController(chestScriptableObject.ChestView, chestModel);
            chestController.SetPosition(slotTransform);
            chestController.TimerText = slot.timer;
            chestController.SetSlot(slot);
            slot.unlockButton.onClick.RemoveAllListeners();
            slot.unlockButton.onClick.AddListener(() => UnlockOptions(chestController));
            activeChestCount++;
        }
        else
        {
            return;
        }
        UIManager.Instance.ChestSpawnControl();
    }

    public void UnlockTimerChest(ChestController chestController)
    {
        chestController.UnlockWithTimer();
    }

    public void UnlockGemsChest(ChestController chestController)
    {
        int unlockGems = chestController.CalculateUnlockGems();
        chestController.UnlockWithGems(unlockGems);
    }

    public void UnlockOptions(ChestController chestController)
    {
        UIManager.Instance.ChestUnlockOptionsControl(chestController);
    }

    public void RemoveChest()
    {
        activeChestCount--;
    }
}
