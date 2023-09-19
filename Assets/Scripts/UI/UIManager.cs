using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Button chestSpawnButton;
    [SerializeField] private TextMeshProUGUI noMoreSlotsText;
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    [SerializeField] private TextMeshProUGUI totalGemsText;
    [SerializeField] private TextMeshProUGUI chestUnlockTimer;
    [SerializeField] private GameObject unlockOptionsPanel;

    private void Start()
    {
        UpdateCurrencyText();
    }

    public void ChestSpawnControl()
    {
        if (ChestSlotManager.Instance.GetNumberOfEmptySlots() > 0)
        {
            chestSpawnButton.interactable = true;
            noMoreSlotsText.gameObject.SetActive(false);
        }
        else
        {
            chestSpawnButton.interactable = false;
            noMoreSlotsText.gameObject.SetActive(true);
        }
    }

    public void UpdateCurrencyText()
    {
        totalCoinsText.text += SystemManager.Instance.TotalCoins;
        totalGemsText.text += SystemManager.Instance.TotalGems;
    }

    public void ChestUnlockTimerControl(float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        chestUnlockTimer.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void ChestUnlockButtonControl(Button chestUnlockButton)
    {
        chestUnlockButton.gameObject.SetActive(!chestUnlockButton.gameObject.activeSelf);
    }

    public void ChestUnlockOptionsControl(ChestController chestController)
    {
        unlockOptionsPanel.gameObject.SetActive(!unlockOptionsPanel.gameObject.activeSelf);
    }
}
