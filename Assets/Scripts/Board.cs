using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour {
    // Start is called before the first frame update

    [SerializeField]
    private int boardWidth; // The width of the board.

    [SerializeField]
    private int boardHeight; // The height of the board.

    [SerializeField]
    private GameObject backgroundTilePrefab; // The prefab for the background tiles.

    [SerializeField]
    Gem[] gems; // An array of gems.

    void Start() {
        // Setup the board.
        Setup();
    }

    private void Setup() {
        // Iterate over each tile on the board.
        for (int x = 0; x < boardWidth; x++) {
            for (int y = 0; y < boardHeight; y++) {

                // Get the current tile's position.
                Vector2 currentTilePosition = new Vector2(x, y);

                // Create a new background tile at the specified position.
                GameObject backgroundTile = Instantiate(backgroundTilePrefab, currentTilePosition, Quaternion.identity);

                // Set the tile's parent to the board.
                backgroundTile.transform.parent = transform;

                // Set the tile's name.
                backgroundTile.name = "BG-Tile [" + x + "," + y + "]";

                // Get a random gem from the array.
                int gemIndex = Random.Range(0, gems.Length);
                Gem gem = gems[gemIndex];

                // Spawn the gem at the specified location.
                SpawnGem(currentTilePosition, gem);
            }
        }
    }

    private void SpawnGem(Vector2 spawnLocation, Gem gem) {
        // Create a new gem at the specified location.
        GameObject gemObject = Instantiate(gem.gameObject, spawnLocation, Quaternion.identity);

        // Set the gem's parent to the board.
        gemObject.transform.parent = transform;

        // Set the gem's name.
        gemObject.name = "Gem [" + spawnLocation.x + "," + spawnLocation.y + "]";
    }
}