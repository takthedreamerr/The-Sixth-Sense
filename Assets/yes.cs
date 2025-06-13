using UnityEngine;

public class HoodieYesButton : MonoBehaviour
{
    public HoodieInteraction hoodie;

    public void OnClickYes()
    {
        if (hoodie != null)
            hoodie.OnYesClicked();
    }
}
