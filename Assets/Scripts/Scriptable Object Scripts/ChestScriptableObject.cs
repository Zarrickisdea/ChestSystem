using UnityEngine;

[CreateAssetMenu(fileName = "ChestScriptableObject", menuName = "ScriptableObjects/ChestScriptableObject")]
public class ChestScriptableObject : ScriptableObject
{
    [SerializeField] private ChestView chestView;
    [SerializeField] private int minCoins;
    [SerializeField] private int maxCoins;
    [SerializeField] private int minGems;
    [SerializeField] private int maxGems;
    [SerializeField] private ChestType chestType;
    [SerializeField] private float unlockTime;

    public ChestView ChestView => chestView;
    public int MinCoins => minCoins;
    public int MaxCoins => maxCoins;
    public int MinGems => minGems;
    public int MaxGems => maxGems;
    public ChestType ChestType => chestType;
    public float UnlockTime => unlockTime;
}
