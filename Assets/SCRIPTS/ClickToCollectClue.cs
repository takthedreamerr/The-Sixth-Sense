using UnityEngine;

public class ClickToCollectClue : MonoBehaviour
{
    void Update()
    {
        if (Input.GetMouseButtonDown(0)) // Left mouse button
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            RaycastHit2D hit = Physics2D.Raycast(mousePos, Vector2.zero);

            if (hit.collider != null && hit.collider.CompareTag("clue"))
            {
                Destroy(hit.collider.gameObject);
            }
        }
    }
}
