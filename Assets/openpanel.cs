using UnityEngine;

public class PanelOpener2D : MonoBehaviour
{
    public GameObject panelToShow;
    private bool panelVisible = false;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            // Convert mouse position to world point
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            // Perform 2D raycast
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("PanelOpener2D: Object clicked!");

                // Open the panel if it's not already visible
                if (!panelVisible && panelToShow != null)
                {
                    panelToShow.SetActive(true);
                    panelVisible = true;
                }
            }
            else
            {
                // Clicked somewhere else – hide the panel if it was open
                if (panelVisible && panelToShow != null)
                {
                    panelToShow.SetActive(false);
                    panelVisible = false;
                }
            }
        }
    }
}
