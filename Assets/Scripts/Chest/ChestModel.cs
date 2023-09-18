public enum ChestType
{
    Common,
    Rare,
    Epic,
    Legendary
}

public class ChestModel
{
    public int MinCoins { get; }
    public int MaxCoins { get; }
    public int MinGems { get; }
    public int MaxGems { get; }
    public ChestType ChestType { get; }
    public float UnlockTime { get; }
    public ChestState ChestState { get; set; }

    public ChestModel (ChestScriptableObject chestScriptableObject)
    {
        MinCoins = chestScriptableObject.MinCoins;
        MaxCoins = chestScriptableObject.MaxCoins;
        MinGems = chestScriptableObject.MinGems;
        MaxGems = chestScriptableObject.MaxGems;
        ChestType = chestScriptableObject.ChestType;
        UnlockTime = chestScriptableObject.UnlockTime;
    }

    public void SetState(ChestState chestState)
    {
        ChestState = chestState;
        ChestState.Enter();
    }
}
