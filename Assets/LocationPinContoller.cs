using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;
using System.Collections.Generic;

public class LocationPinByTilemap : MonoBehaviour
{
    [SerializeField] private Transform player;
    [SerializeField] private Image locationPin;

    [System.Serializable]
    struct RoomData
    {
        public Tilemap tilemap;   // The tilemap for this room
        public Sprite pinSprite;  // The UI sprite to show
    }

    [SerializeField] private List<RoomData> rooms;

    void Update()
    {
        Vector3Int playerCell = Vector3Int.zero;
        if (player != null)
            playerCell = rooms[0].tilemap.WorldToCell(player.position);

        bool found = false;
        foreach (var room in rooms)
        {
            Vector3Int cell = room.tilemap.WorldToCell(player.position);
            if (room.tilemap.GetTile(cell) != null)
            {
                locationPin.sprite = room.pinSprite;
                locationPin.enabled = true;
                found = true;
                break;
            }
        }

        if (!found)
            locationPin.enabled = false;
    }
}
