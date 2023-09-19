using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : GenericSingleton<UIManager>
{
    [SerializeField] private Button chestSpawnButton;
    [SerializeField] private TextMeshProUGUI noMoreSlotsText;
    [SerializeField] private TextMeshProUGUI totalCoinsText;
    [SerializeField] private TextMeshProUGUI totalGemsText;
    [SerializeField] private TextMeshProUGUI warningText;
    [SerializeField] private GameObject unlockOptionsPanel;

    public void WarningTextControl(string text)
    {
        warningText.text = text;
        warningText.gameObject.SetActive(true);
        StartCoroutine(WarningTextTimer());
    }

    private void Start()
    {
        UpdateCurrencyText();
    }

    private IEnumerator WarningTextTimer()
    {
        yield return new WaitForSeconds(2f);
        warningText.gameObject.SetActive(false);
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
        totalCoinsText.text = "Coins: " + SystemManager.Instance.TotalCoins;
        totalGemsText.text = "Gems: " + SystemManager.Instance.TotalGems;
    }

    public void ChestUnlockTimerControl(TextMeshProUGUI timerText, float time)
    {
        int hours = Mathf.FloorToInt(time / 3600);
        int minutes = Mathf.FloorToInt((time % 3600) / 60);
        int seconds = Mathf.FloorToInt(time % 60);

        timerText.text = string.Format("{0:00}:{1:00}:{2:00}", hours, minutes, seconds);
    }

    public void SetObjectState(GameObject gameobject, bool state)
    {
        gameobject.SetActive(state);
    }

    public void ChestUnlockOptionsControl(ChestController chestController)
    {
        unlockOptionsPanel.gameObject.SetActive(!unlockOptionsPanel.gameObject.activeSelf);
        if (unlockOptionsPanel.gameObject.activeSelf)
        {
            Button[] buttons = unlockOptionsPanel.GetComponentsInChildren<Button>();

            foreach (Button button in buttons)
            {
                button.onClick.RemoveAllListeners();
            }

            buttons[0].onClick.AddListener(() => ChestManager.Instance.UnlockGemsChest(chestController));
            buttons[0].onClick.AddListener(() => unlockOptionsPanel.gameObject.SetActive(false));
            buttons[0].GetComponentInChildren<TextMeshProUGUI>().text = "Unlock With: " + chestController.CalculateUnlockGems().ToString() + " Gems";
            buttons[1].onClick.AddListener(() => ChestManager.Instance.UnlockTimerChest(chestController));
            buttons[1].onClick.AddListener(() => unlockOptionsPanel.gameObject.SetActive(false));

        }
    }
}
