using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    // Start is called before the first frame update

    [SerializeField]
    private int width; // The width of the board.

    [SerializeField]
    private int height; // The height of the board.

    [SerializeField]
    private GameObject bgTilePrefab; // The prefab for the background tiles.

 
    void Start()
    {
        // Setup the board.
        Setup();
    }

    private void Setup()
    {
        // Iterate over each tile on the board.
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Create a new background tile at the specified position.
                GameObject bgTile = Instantiate(bgTilePrefab, new Vector2(x, y), Quaternion.identity);

                // Set the tile's parent to the board.
                bgTile.transform.parent = transform;

                // Set the tile's name.
                bgTile.name = "BG-Tile [" + x + "," + y + "]";
            }
        }
    }

}