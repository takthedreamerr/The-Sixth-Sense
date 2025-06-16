using System.Collections;
using UnityEngine;

public class FloatingObjectInteraction : MonoBehaviour
{
    public float amplitude = 0.5f;
    public float frequency = 1f;

    public GameObject infoPanel;
    public GameObject hoodieObject;
    public float delayBeforeHoodieStarts = 1.5f;

    private Vector3 startPos;
    private bool isBouncing = true;
    private bool panelVisible = false;

    void Start()
    {
        startPos = transform.position;

        if (infoPanel != null)
            infoPanel.SetActive(false);
    }

    void Update()
    {
        if (isBouncing)
        {
            Vector3 tempPos = startPos;
            tempPos.y += Mathf.Sin(Time.time * Mathf.PI * frequency) * amplitude;
            transform.position = tempPos;
        }

        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.gameObject == this.gameObject)
            {
                Debug.Log("Floating object clicked!");

                StopBouncing();

                if (infoPanel != null && !panelVisible)
                {
                    infoPanel.SetActive(true);
                    panelVisible = true;
                }
            }
            else if (panelVisible)
            {
                infoPanel.SetActive(false);
                panelVisible = false;

                StartCoroutine(StartHoodieAfterDelay());
            }
        }
    }

    void StopBouncing()
    {
        isBouncing = false;
        transform.position = startPos;
    }

    IEnumerator StartHoodieAfterDelay()
    {
        yield return new WaitForSeconds(delayBeforeHoodieStarts);

        HoodieInteraction hoodie = hoodieObject.GetComponent<HoodieInteraction>();
        if (hoodie != null)
            hoodie.EnableInteraction();
    }
}
