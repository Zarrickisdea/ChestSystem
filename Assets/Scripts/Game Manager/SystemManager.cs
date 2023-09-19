using UnityEngine;

public class SystemManager : GenericSingleton<SystemManager>
{
    [SerializeField] private int totalCoins;
    [SerializeField] private int totalGems;

    public int TotalCoins => totalCoins;
    public int TotalGems => totalGems;

    public void AddCoins(int coins)
    {
        totalCoins += coins;
    }

    public void AddGems(int gems)
    {
        totalGems += gems;
    }

    public void RemoveCoins(int coins)
    {
        totalCoins -= coins;
    }

    public void RemoveGems(int gems)
    {
        totalGems -= gems;
    }
}
