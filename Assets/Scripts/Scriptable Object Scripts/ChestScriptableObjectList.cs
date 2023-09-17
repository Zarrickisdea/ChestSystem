using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObjectList", menuName = "ScriptableObjects/ChestScriptableObjectList")]
public class ChestScriptableObjectList : ScriptableObject
{
    [SerializeField] private List<ChestScriptableObject> chestScriptableObjectList;

    public ChestScriptableObject GetChest()
    {
        return chestScriptableObjectList[Random.Range(0, chestScriptableObjectList.Count)];
    }
}
