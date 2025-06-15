using UnityEngine;
using UnityEngine.UI;

public class DisableButtonWhenVisible : MonoBehaviour
{
    public GameObject[] targetObjects; // Assign the 6 GameObjects here in the Inspector
    public Button buttonToDisable;     // Assign the button to disable

    void Update()
    {
        // Check if all target objects are active (visible in scene)
        bool allVisible = true;

        foreach (GameObject obj in targetObjects)
        {
            if (!obj.activeInHierarchy) // Or use obj.GetComponent<Renderer>().enabled if needed
            {
                allVisible = false;
                break;
            }
        }

        if (allVisible && buttonToDisable.interactable) // Disable only once
        {
            buttonToDisable.interactable = false;
            Debug.Log("All objects visible — button disabled.");
        }
    }
}
