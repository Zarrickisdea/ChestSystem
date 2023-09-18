using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;

    public void CreateChest()
    {
        ChestScriptableObject chestScriptableObject = chestScriptableObjectList.GetChest();
        ChestModel chestModel = new ChestModel(chestScriptableObject);
        ChestController chestController = new ChestController(chestScriptableObject.ChestView, chestModel);
        chestController.SetController();
        chestController.SetPosition(SystemManager.Instance.GetSlotPosition());
    }
}
