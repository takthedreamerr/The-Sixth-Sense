using UnityEngine;

public class MurderWeapon : MonoBehaviour
{
    public GameObject congratulationsPanel; // Assign in Inspector

    private bool hasBeenClicked = false;

    private void OnMouseDown()
    {
        if (!hasBeenClicked)
        {
            hasBeenClicked = true;
            if (congratulationsPanel != null)
            {
                congratulationsPanel.SetActive(true); // Show the panel
            }
        }
    }
}

