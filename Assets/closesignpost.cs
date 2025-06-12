using UnityEngine;

public class HidePanelOnClick : MonoBehaviour
{
    public GameObject panelToHide;

    void Update()
    {
        if (panelToHide.activeSelf && Input.GetMouseButtonDown(0))
        {
            panelToHide.SetActive(false);
        }
    }
}
