using UnityEngine;

public class SystemManager : GenericSingleton<SystemManager>
{
    [SerializeField] private ChestSlotManager chestSlotManager;
    [SerializeField] private ChestManager chestManager;

    private void Start()
    {
        if (chestSlotManager != null)
        {
            chestSlotManager.gameObject.SetActive(true);
        }

        if (chestManager != null)
        {
            chestManager.gameObject.SetActive(true);
        }
    }

    public Vector3 GetSlotPosition()
    {
        return chestSlotManager.GetEmptyPosition();
    }

    public int GetNumberOfSlots()
    {
        return chestSlotManager.GetNumberOfSlots();
    }
}
