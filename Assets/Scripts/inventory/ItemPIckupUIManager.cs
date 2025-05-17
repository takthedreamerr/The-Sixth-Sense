using UnityEngine;
using UnityEngine.UI;

public class ItemPickupUIManager : MonoBehaviour
{
    public GameObject confirmationPanel;
    public Button yesButton;
    public Button noButton;
    private ItemPickup currentItem;

    void Start()
    {
        confirmationPanel.SetActive(false);
        yesButton.onClick.AddListener(OnYesClicked);
        noButton.onClick.AddListener(OnNoClicked);
    }

    public void ShowConfirmation(ItemPickup item)
    {
        currentItem = item;
        confirmationPanel.SetActive(true);
    }

    public void HideConfirmation()
    {
        confirmationPanel.SetActive(false);
    }

    private void OnYesClicked()
    {
        currentItem.AddToInventory();
        confirmationPanel.SetActive(false);
    }

    private void OnNoClicked()
    {
        currentItem.LeaveItemInScene();
        confirmationPanel.SetActive(false);
    }
}
