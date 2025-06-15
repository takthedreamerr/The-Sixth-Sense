using UnityEngine;

public class HidePanelOnClick : MonoBehaviour
{
    public GameObject panelToHide;
    private bool canHide = false;

    void OnEnable()
    {
        canHide = false;
        Invoke("EnableHide", 0.1f); // Wait a short time before allowing hide
    }

    void EnableHide()
    {
        canHide = true;
    }

    void Update()
    {
        if (canHide && panelToHide.activeSelf && Input.GetMouseButtonDown(0))
        {
            panelToHide.SetActive(false);
        }
    }
}
