using UnityEngine;

public class ChestManager : MonoBehaviour
{
    [SerializeField] private ChestScriptableObjectList chestScriptableObjectList;

    private void Start()
    {
        CreateChest();
    }

    private void CreateChest()
    {
        ChestScriptableObject chestScriptableObject = chestScriptableObjectList.GetChest();
        ChestModel chestModel = new ChestModel(chestScriptableObject);
        ChestController chestController = new ChestController(chestScriptableObject.ChestView, chestModel);
    }
}
