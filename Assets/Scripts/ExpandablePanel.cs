using UnityEngine;
using UnityEngine.UI;

 //Titel:Expandable UI Panel
 //Author:Naledi 
 //collaborator:ChatGPT (OpenAI)
 //code Version: 1

public class ExpandablePanel : MonoBehaviour
{
    public GameObject panel;     
    public Button toggleButton;  

    private bool isPanelVisible = false;

    void Start()
    {
       
        panel.SetActive(false);

        
        toggleButton.onClick.AddListener(TogglePanel);
    }

    void TogglePanel()
    {
        isPanelVisible = !isPanelVisible;
        panel.SetActive(isPanelVisible);
    }
}