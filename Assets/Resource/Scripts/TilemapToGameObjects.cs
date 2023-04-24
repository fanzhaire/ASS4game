using UnityEngine;
using UnityEngine.Tilemaps;

public class TilemapToGameObjects : MonoBehaviour
{
    public Tilemap sourceTilemap;
    public GameObject tilePrefab;

    void Start()
    {
        ConvertTilemapToGameObjects();
    }

    void ConvertTilemapToGameObjects()
    {
        BoundsInt bounds = sourceTilemap.cellBounds;
        TileBase[] allTiles = sourceTilemap.GetTilesBlock(bounds);

        for (int x = 0; x < bounds.size.x; x++)
        {
            for (int y = 0; y < bounds.size.y; y++)
            {
                TileBase tile = allTiles[x + y * bounds.size.x];
                if (tile != null)
                {
                    Vector3Int localPlace = new Vector3Int(x, y, (int)sourceTilemap.transform.position.z);
                    Vector3 place = sourceTilemap.CellToWorld(localPlace);
                    GameObject newTileObject = Instantiate(tilePrefab, place, Quaternion.identity);
                    newTileObject.GetComponent<SpriteRenderer>().sprite = ((Tile)tile).sprite;
                }
            }
        }
    }
}
