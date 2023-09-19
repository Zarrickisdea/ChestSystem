using UnityEngine;

public class ChestManager : GenericSingleton<ChestManager>
{
    [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;

    public void CreateChest()
    {
        Slot slot = ChestSlotManager.Instance?.GetEmptySlot();
        if (slot != null)
        {
            Transform slotTransform = slot.slotObject.transform;
            ChestScriptableObject chestScriptableObject = chestScriptableObjectList.GetChest();
            ChestModel chestModel = new ChestModel(chestScriptableObject);
            ChestController chestController = new ChestController(chestScriptableObject.ChestView, chestModel);
            chestController.SetPosition(slotTransform);
            slot.unlockButton.onClick.AddListener(() => UnlockOptions(chestController));
        }
        else
        {
            return;
        }
        UIManager.Instance.ChestSpawnControl();
    }

    public void UnlockChest(ChestController chestController)
    {
        chestController.SetState(new ChestUnlockedState(chestController.ChestView));
    }

    public void UnlockOptions(ChestController chestController)
    {
        UIManager.Instance.ChestUnlockOptionsControl(chestController);
    }
}
